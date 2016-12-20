using System;
using System.Collections.Generic;

namespace Common.ApiGateway.Models
{
    public class ContactsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public string Nickname { get; set; }
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime? Birthday { get; set; }
        public string Notes { get; set; }

        //public IList<ContactGroupsModel> ContactGroups { get; set; }
    }
}
