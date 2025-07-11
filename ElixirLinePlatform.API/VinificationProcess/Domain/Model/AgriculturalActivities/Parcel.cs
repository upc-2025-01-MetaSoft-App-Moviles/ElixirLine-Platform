using System;

namespace ElixirLinePlatform.API.VinificationProcess.Domain.Model.AgriculturalActivities
{
    public class Parcel
    {
        public Guid ParcelId { get; private set; }
        public string Name { get; private set; }
        public double Area { get; private set; }
        public string CropType { get; private set; }
        public string Location { get; private set; }
        public TaskStage Stage { get; private set; }

        public Parcel(Guid parcelId, string name, double area, string cropType, string location, TaskStage stage)
        {
            if (area <= 0)
                throw new ArgumentException("El área debe ser mayor que cero.");

            ParcelId = parcelId;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Area = area;
            CropType = cropType ?? throw new ArgumentNullException(nameof(cropType));
            Location = location ?? throw new ArgumentNullException(nameof(location));
            Stage = stage;
        }

        public void Update(string name, double area, string cropType, string location, TaskStage stage)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("El nombre no puede estar vacío.");
            if (area <= 0)
                throw new ArgumentException("El área debe ser mayor que cero.");
            if (string.IsNullOrWhiteSpace(cropType))
                throw new ArgumentException("El tipo de cultivo no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(location))
                throw new ArgumentException("La ubicación no puede estar vacía.");

            Name = name;
            Area = area;
            CropType = cropType;
            Location = location;
            Stage = stage;
        }
    }
}
