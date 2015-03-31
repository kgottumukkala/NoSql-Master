using System;
using System.Collections.Generic;

namespace NoSqlWeb.Models
{
    public class PostUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        //public List<Contact> Contacts = new List<Contact>();
        public DateTime CreatedDate { get; set; }
    }
}