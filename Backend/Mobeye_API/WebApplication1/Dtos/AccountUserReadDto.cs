using Mobeye_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobeye_API.Dtos
{
    public class AccountUserReadDto
    {
        public Guid Id { get; set; }
        public string PhoneIMEI { get; set; }
        public string SMSCode { get; set; }
        public string RegistrationPrivateKey { get; set; } // send back from Mobeye after registration request
        public string AuthPrivateKey { get; set; } // send back from Mobeye after authorization request
        public string Role { get; set; }
        public ICollection<Device> Devices { get; set; }
        public ICollection<Alarm> Alarms { get; set; }
    }
}
