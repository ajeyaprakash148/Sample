using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Common.ApiGateway.Entities
{
    public class GroupsEntity : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string GroupCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<ContactGroupsEntity> ContactGroups { get; set; }
    }
}
