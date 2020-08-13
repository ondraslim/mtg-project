using System;

namespace DAL.Common.Model.Common
{
    public class SoftDeleteEntity : EntityBase
    {

        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public DateTime? Deleted { get; set; }
    }
}