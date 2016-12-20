using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.ApiGateway.Entities
{
    public class BaseEntity
    {
        public DateTime? DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public decimal? OwnerOrgId { get; set; }

        public string OwnerLocId { get; set; }

        public string StateId { get; set; }

        public bool? DeletedInd { get; set; }

        public BaseEntity()
        {
            DateCreated = DateTime.UtcNow;
            DateModified = DateTime.UtcNow;
            DeletedInd = false;
        }

        public virtual void UpdateAuditFields()
        {
            DateModified = DateTime.UtcNow;
        }
    }
}
