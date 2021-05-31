using System;

namespace InfrastructureLayer
{
    public class AircraftDM
    {
        public int AircraftId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Registration { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
