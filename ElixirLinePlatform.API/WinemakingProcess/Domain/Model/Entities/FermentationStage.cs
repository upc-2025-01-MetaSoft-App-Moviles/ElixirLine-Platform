using System.Globalization;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.ValueObjects;

namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;


/// <summary>
/// Fermentation stage: conversion of sugars into alcohol.
/// </summary>
public class FermentationStage : WinemakingStage
{
    
    public string YeastUsed { get; private set; }
    public double TemperatureMax { get; private set; }
    public double TemperatureMin { get; private set; }
    public double InitialSugarLevel { get; private set; }
    public double FinalSugarLevel { get; private set; }
    public double InitialPh { get; private set; }
    public double FinalPh { get; private set; }
    public string FermentationType { get; private set; }
    public string TankCode { get; private set; }
    public int DurationInDays => IsCompleted ? (CompletedAt.Value - StartedAt).Days : 0;
    
    
    
    public FermentationStage() : base(StageType.Fermentation, DateTime.Now, null)
    {
        YeastUsed = string.Empty;
        TemperatureMax = 0;
        TemperatureMin = 0;
        InitialSugarLevel = 0;
        FinalSugarLevel = 0;
        InitialPh = 0;
        FinalPh = 0;
        FermentationType = string.Empty;
        TankCode = string.Empty;

        CompletedBy = null;
    }
    
    
    
    /// Constructor de inicialización para la creación de una etapa de recepción
    public FermentationStage(
        string yeastUsed,
        double initialBrix,
        double finalBrix,
        double initialPh,
        double finalPh,
        double temperatureMax,
        double temperatureMin,
        string fermentationType,
        string tankCode,
        string startedAt,
        string? completedBy,
        string? observations)
        : base(StageType.Fermentation, ParseDate(startedAt), observations)
    {
        YeastUsed = yeastUsed;
        InitialSugarLevel = initialBrix;
        FinalSugarLevel = finalBrix;
        InitialPh = initialPh;
        FinalPh = finalPh;
        TemperatureMax = temperatureMax;
        TemperatureMin = temperatureMin;
        FermentationType = fermentationType;
        TankCode = tankCode;
        
        CompletedBy = completedBy;
    }
    
    /// Constructor para crear una etapa de fermentación a partir de un comando
    public FermentationStage (AddFermentationStageCommand command) 
        : base(StageType.Fermentation, ParseDate(command.startedAt), command.observations)
    {
        YeastUsed = command.yeastUsed;
        InitialSugarLevel = command.initialBrix;
        FinalSugarLevel = command.finalBrix;
        InitialPh = command.initialPh;
        FinalPh = command.finalPh;
        TemperatureMax = command.temperatureMax;
        TemperatureMin = command.temperatureMin;
        FermentationType = command.fermentationType;
        TankCode = command.tankCode;

        CompletedBy = command.completedBy;
    }
    
    
    public override void Update(WinemakingStage updatedStage)
    {
        if (updatedStage is not FermentationStage updated)
            throw new InvalidOperationException("Tipo incorrecto: se esperaba FermentationStage.");

        
        YeastUsed = updated.YeastUsed;
        InitialSugarLevel = updated.InitialSugarLevel;
        FinalSugarLevel = updated.FinalSugarLevel;
        InitialPh = updated.InitialPh;
        FinalPh = updated.FinalPh;
        TemperatureMax = updated.TemperatureMax;
        TemperatureMin = updated.TemperatureMin;
        FermentationType = updated.FermentationType;
        TankCode = updated.TankCode;

        Observations = updated.Observations;
        CompletedAt = updated.CompletedAt;
        CompletedBy = updated.CompletedBy;
    }

    public override void Delete()
    {
        YeastUsed = string.Empty;
        InitialSugarLevel = 0;
        FinalSugarLevel = 0;
        InitialPh = 0;
        FinalPh = 0;
        TemperatureMax = 0;
        TemperatureMin = 0;
        FermentationType = string.Empty;
        TankCode = string.Empty;
        
        Observations = null;
        CompletedAt = null;
        CompletedBy = null;
    }
    
    
    private static DateTime ParseDate(string date)
    {
        if (!DateTime.TryParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsed))
            throw new FormatException("La fecha debe estar en formato dd/MM/yyyy.");
        return parsed;
    }
    
    public override void AssignBatchId(Guid batchId)
    {
        BatchId = batchId;
    }
}