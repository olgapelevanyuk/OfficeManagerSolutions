using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeManager.Services.Models
{
    public class EmployeeRequest
    {
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
    }
}
