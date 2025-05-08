using System.Globalization;
using ElixirLinePlatform.API.WinemakingProcess.Domain.Model.ValueObjects;

namespace ElixirLinePlatform.API.WinemakingProcess.Domain.Model.Entities;

public class BottlingStage : WinemakingStage
{
    public string BottleType { get; private set; } // Type of bottle (e.g. Bordeaux, Burgundy)
    public int BottleCount { get; private set; } // Number of bottles filled
    public string BottleVolume { get; private set; } // Volume per bottle (e.g. 750ml)
    public string ClosureType { get; private set; } // Type of seal (cork, screw cap, etc.)
    public string BatchLabelCode { get; private set; } // Traceable code for bottle labeling
    public string OperatorName { get; private set; } // Who performed the bottling
    
    // ========= Constructor por defecto para inicializar la clase
    public BottlingStage()
        : base(StageType.Bottling, string.Empty)
    {
        BottleType = string.Empty;
        BottleCount = 0;
        BottleVolume = string.Empty;
        ClosureType = string.Empty;
        BatchLabelCode = string.Empty;
        OperatorName = string.Empty;
    }
    
    public BottlingStage(DateTime startedAt, string bottleType, int bottleCount, string bottleVolume, string closureType, string batchLabelCode, string operatorName)
        : base(StageType.Bottling, string.Empty)
    {
        // ========= Validar formato de fecha
        if (!DateTime.TryParseExact(startedAt.ToString("dd/MM/yyyy"), "dd/MM/yyyy", null, DateTimeStyles.None, out DateTime parsedDate))
        {
            throw new FormatException("La fecha debe estar en formato DD/MM/AAAA en el constructor de BottlingStage.");
        }
        // ========= Inicialización de datos de la clase abstracta WinemakingStage
        Id = Guid.NewGuid();
        StartedAt = parsedDate;
        StageType = StageType.Bottling;
        
        BottleType = bottleType;
        BottleCount = bottleCount;
        BottleVolume = bottleVolume;
        ClosureType = closureType;
        BatchLabelCode = batchLabelCode;
        OperatorName = operatorName;
    }
    
    
    // ========== Constructor de inicialización para la creación de una etapa de embotellado con command
    
    /*
    public BottlingStage(AddBottlingStageCommand command): this()
    {
        // ========== Validar formato de fecha
        if (!DateTime.TryParseExact(command.startedAt, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
        {
            throw new FormatException("La fecha debe estar en formato DD/MM/AAAA en el constructor de BottlingStage.");
        }
        
        // ========= Inicialización de datos de la clase abstracta WinemakingStage
        Id = Guid.NewGuid();
        StartedAt = parsedDate;
        StageType = StageType.Bottling;
        
        BottleType = command.bottleType;
        BottleCount = command.bottleCount;
        BottleVolume = command.bottleVolume;
        ClosureType = command.closureType;
        BatchLabelCode = command.batchLabelCode;
        OperatorName = command.operatorName;
    }
    */
    
    
    
}