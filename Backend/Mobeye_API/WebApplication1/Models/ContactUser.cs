using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobeye_API.Models
{
    public class ContactUser : User
    {
        public ICollection<Alarm> Alarms { get; set; }
    }
}
