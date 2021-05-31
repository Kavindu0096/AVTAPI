using System;
using System.Collections.Generic;

#nullable disable

namespace RepositoryLayer.DB
{
    public partial class TblAircraftSighting
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Registration { get; set; }
        public int? AircraftId { get; set; }
        public string Location { get; set; }
        public DateTime? SightingAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
