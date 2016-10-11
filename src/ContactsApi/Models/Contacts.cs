using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApi.Models
{
    public class Contacts
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsFamilyMember { get; set; }
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime AnniversaryDate { get; set; }
    }
}
