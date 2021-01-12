using System;
using System.Collections.Generic;
using System.Text;

namespace MainApp.Models
{
    public class Contact
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAdress { get; set; }
        public string PhotoURL { get; set; }
        public string Job { get; set; }
        public bool Favorite{ get; set; }

    }
}
