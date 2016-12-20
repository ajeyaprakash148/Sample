using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Common.ApiGateway.Models
{
    public class ClientModel
    {
        public int ClientId { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
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
