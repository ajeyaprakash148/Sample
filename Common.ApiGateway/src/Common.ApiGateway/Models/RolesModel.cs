using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.ApiGateway.Models
{
    public class RolesModel
    {
        public string RoleId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? DateCreated { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? DateModified { get; set; }

        public string ModifiedBy { get; set; }

        public string StateId { get; set; }

        public decimal? OwnerOrgId { get; set; }

        public int OrgLevelPerm { get; set; }

        public int RowLevelPerm { get; set; }

        public string OwnerLocId { get; set; }

        public int? IsInBoxEnabled { get; set; }

        public string Disable { get; set; }

        public bool? DeletedInd { get; set; }

    }
}
