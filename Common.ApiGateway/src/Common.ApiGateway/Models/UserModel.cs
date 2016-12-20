using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.ApiGateway.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }

        public string FamilyName { get; set; }

        public string ProfilePicture { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }

        public DateTime? LastLogonTime { get; set; }

        public bool AccountStatus { get; set; }

        public DateTime? LoginExpiryDate { get; set; }

        public DateTime? DateCreated { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? DateModified { get; set; }

        public string ModifiedBy { get; set; }

        public decimal? OwnerOrgId { get; set; }

        public string ThemeId { get; set; }

        public string OwnerLocId { get; set; }

        public bool IsLocked { get; set; }

        public bool IsDisabled { get; set; }

        public decimal? UserCultureId { get; set; }

        public DateTime? TokenExpiry { get; set; }

        public string ActualName { get; set; }

        public string Email { get; set; }

        public string MobileNumber { get; set; }

        public bool? DeletedInd { get; set; }

        public string UserLocale { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Gender { get; set; }

        public bool? EmailVerified { get; set; }
    }
}
