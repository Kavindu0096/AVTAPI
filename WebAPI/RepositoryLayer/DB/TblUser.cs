using System;
using System.Collections.Generic;

#nullable disable

namespace RepositoryLayer.DB
{
    public partial class TblUser
    {
        public int UserId { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
