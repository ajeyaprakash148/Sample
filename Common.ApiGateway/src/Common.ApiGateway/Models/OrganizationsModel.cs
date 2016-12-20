using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.ApiGateway.Models
{
    public class OrganizationsModel
    {
        public int OrganizationId { get; set; }

        public decimal? OrganizationTypeId { get; set; }

        public string Name { get; set; }

        public string OrganizationCode { get; set; }

        public string Description { get; set; }

        public string TradeLicenseNumber { get; set; }

        public string Trading_Group_Short_Name { get; set; }

        public DateTime? DateCreated { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? DateModified { get; set; }

        public string ModifiedBy { get; set; }

        public string StateId { get; set; }

        public decimal? OwnerOrgId { get; set; }

        public decimal? InsurancePremium { get; set; }

        public decimal? ClientConductStatusId { get; set; }

        public string GCCImporter { get; set; }

        public decimal? CustomClientConductStatusId { get; set; }

        public string OwnerLocId { get; set; }

        public bool? AccessEnable { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public int? CountryId { get; set; }

        public bool? IsOrgUpdate { get; set; }

        public bool? DeletedInd { get; set; }

        public int? IndustryId { get; set; }

        public int? StrengthId { get; set; }

        public int? LocationId { get; set; }

        public string Phone { get; set; }

        public string OrganizationLogo { get; set; }

        public int? CompanyId { get; set; }

        public int? AddressId { get; set; }

        public int? ContactId { get; set; }

        public int? ParentOrganizationID { get; set; }

        public string BillingAddress { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }
    }
}
