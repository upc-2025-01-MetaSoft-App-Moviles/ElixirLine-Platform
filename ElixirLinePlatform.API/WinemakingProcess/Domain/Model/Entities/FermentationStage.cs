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
    public double InitialSugarLevel { get; private set; }
    public double FinalSugarLevel { get; private set; }
    public double Temperature { get; private set; }
    public bool MalolacticFermentation { get; private set; }
    public string TankCode { get; private set; }
    public int DurationInDays => IsCompleted ? (CompletedAt.Value - StartedAt).Days : 0;
    
    /// Constructor de inicialización para la creación de una etapa de recepción
    private FermentationStage() : base(StageType.Fermentation, string.Empty)
    {
        YeastUsed = string.Empty;
        InitialSugarLevel = 0;
        FinalSugarLevel = 0;
        Temperature = 0;
        MalolacticFermentation = false;
        TankCode = string.Empty;
    }

    public FermentationStage(DateTime startedAt, string yeastUsed, double initialSugarLevel, double temperature, bool malo, string tankCode)
        : base(StageType.Fermentation, string.Empty)
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
        MalolacticFermentation = malo;
        TankCode = tankCode;
    }
    
    
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
        
        // ========== Inicializar propiedades con valores del command
        YeastUsed = command.yeastUsed;
        InitialSugarLevel = command.initialSugarLevel;
        Temperature = command.temperature;
        MalolacticFermentation = command.malo;
        TankCode = command.tankCode;
    }

    public void CompleteFermentation(DateTime completedAt, double finalBrix)
    {
        FinalSugarLevel = finalBrix;
        Complete(completedAt);
    }
    
    
}