using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeManager.DataAccess.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        public string PassportSerialNumber { get; set; }
        public string PassportNumber { get; set; }
        public string RegistrationCity { get; set; }
        public string City { get; set; }
        public string Adderss { get; set; }
        public string MobilePhone { get; set; }
        public string Nationality { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
