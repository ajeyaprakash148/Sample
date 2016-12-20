using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.ApiGateway.Models
{
    public class ContactGroupsModel
    {
        public int Id { get; set; }
        public int GroupId { get; set; }

        //public GroupsModel Groups { get; set; }
        public int ContactId { get; set; }

        public ContactsModel Contacts { get; set; }
    }
}
