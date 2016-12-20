using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Common.ApiGateway.Entities
{
    public class RolesEntity : BaseEntity
    {
        [Key]
        public string RoleId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int OrgLevelPerm { get; set; }

        public int RowLevelPerm { get; set; }

        public int? IsInBoxEnabled { get; set; }

        public string Disable { get; set; }

        public IList<UserRolesEntity> UserRoles { get; set; }

    }
}
