using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Common.ApiGateway.Entities
{
    public class UserRolesEntity : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string UserId { get; set; }
        public UserEntity User { get; set; }

        public string RoleId { get; set; }
        public RolesEntity Role { get; set; }
    }
}
