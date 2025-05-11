using System.Globalization;
using System.Runtime.CompilerServices;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Commands;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.ValueObjects;

namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;


/// <summary>
/// Fermentation stage: conversion of sugars into alcohol.
/// </summary>
public class FermentationStage : WinemakingStage
{
    public string YeastUsed { get; private set; }
    public double Temperature { get; private set; }
    public double InitialSugarLevel { get; private set; }
    public double FinalSugarLevel { get; private set; }
    public double InitialPH { get; private set; }
    public double FinalPH { get; private set; }
    public double MaxFermentationTempC  {get; private set; }
    public double MinFermentationTempC {  get; private set; }
    public string FermentationType { get; private set; }
    public string TankCode { get; private set; }
    public bool FermentationCompleted { get; private set; }
    public int DurationInDays => IsCompleted ? (CompletedAt.Value - StartedAt).Days : 0;
    
    /// Constructor de inicialización para la creación de una etapa de recepción
    private FermentationStage() : base(StageType.Fermentation, string.Empty)
    {
        YeastUsed = string.Empty;
        InitialSugarLevel = 0;
        FinalSugarLevel = 0;
        Temperature = 0;
        TankCode = string.Empty;
        InitialPH = 0;
        FinalPH = 0;
        MaxFermentationTempC = 0;
        MinFermentationTempC = 0;
        FermentationType = string.Empty;
        FermentationCompleted = false;
        CompletedBy = string.Empty;
        Observations = string.Empty;
        InitialSugarLevel = 0;
        
    }

    
    
    
    // Constructor de inicialización para la creación de una etapa de recepción
    public FermentationStage( DateTime startedAt, string completedBy, string yeastUsed, double initialSugarLevel, double temperature, string tankCode, double initialPH, double finalPH, double maxFermentationTempC, double minFermentationTempC, string fermentationType, bool fermentationCompleted, string observations) : base(StageType.Fermentation, string.Empty)
    {
        // ========= Validar formato de fecha
        if (!DateTime.TryParseExact(startedAt.ToString("dd/MM/yyyy"), "dd/MM/yyyy", null, DateTimeStyles.None,
                out DateTime parsedDate))
        {
            throw new FormatException("La fecha debe estar en formato DD/MM/AAAA en el constructor de PressingStage.");
        }

        // ========= Inicialización de datos de la clase abstracta WinemakingStage
        Id = Guid.NewGuid();
        StartedAt = parsedDate;
        StageType = StageType.Pressing;
        
        YeastUsed = yeastUsed;
        InitialSugarLevel = initialSugarLevel;
        Temperature = temperature;
        TankCode = tankCode;
        InitialPH = initialPH;
        FinalPH = finalPH;
        MaxFermentationTempC = maxFermentationTempC;
        MinFermentationTempC = minFermentationTempC;
        FermentationType = fermentationType;
        FermentationCompleted = fermentationCompleted;
        CompletedBy = completedBy;
        Observations = observations;
        InitialSugarLevel = initialSugarLevel;
    }
    
    
    // Constructor de inicialización para la creación de una etapa de recepción con un command
    public FermentationStage(AddFermentationStageCommand command): this()
    {
        // ========== Validar formato de fecha
        if (!DateTime.TryParseExact(command.startedAt, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
        {
            throw new FormatException("La fecha debe estar en formato DD/MM/AAAA en el constructor de FermentationStage.");
        }
        
        // ========== Inicialización de datos de la clase abstracta WinemakingStage
        Id = Guid.NewGuid();
        StartedAt = parsedDate;
        StageType = StageType.Fermentation;
        CompletedBy = command.completedBy;
        Observations = command.observations;
        
        // ========== Inicializar propiedades con valores del command
        YeastUsed = command.yeastUsed;
        InitialSugarLevel = command.initialSugarLevel;
        Temperature = command.temperature;
        TankCode = command.tankCode;
        
        InitialPH = command.initialPH;
        FinalPH = command.finalPH;
        MaxFermentationTempC = command.maxFermentationTempC;
        MinFermentationTempC = command.minFermentationTempC;
        FermentationType = command.fermentationType;
        FermentationCompleted = command.fermentationCompleted;
        InitialSugarLevel = command.initialSugarLevel;
        
    }

    public void CompleteFermentation(DateTime completedAt, double finalBrix)
    {
        FinalSugarLevel = finalBrix;
        Complete(completedAt);
    }
    
    
}