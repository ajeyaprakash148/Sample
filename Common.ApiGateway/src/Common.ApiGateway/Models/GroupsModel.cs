using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.ApiGateway.Models
{
    public class GroupsModel
    {
        public int Id { get; set; }
        public string GroupCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<ContactGroupsModel> ContactGroups { get; set; }
        public DateTime? DateCreated { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? DateModified { get; set; }

        public string ModifiedBy { get; set; }

        public string StateId { get; set; }

        public decimal? OwnerOrgId { get; set; }

        public string OwnerLocId { get; set; }

        public bool? DeletedInd { get; set; }
    }
}
