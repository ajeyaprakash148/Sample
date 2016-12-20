using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Common.ApiGateway.Entities
{
    public class ContactGroupsEntity : BaseEntity
    {

        public int Id { get; set; }
        public int GroupId { get; set; }

        public GroupsEntity Groups { get; set; }
        public int ContactId { get; set; }

        public ContactsEntity Contacts { get; set; }
    }
}
