using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mobeye_API.Models
{
    public class Device
    {
        [Key]
        public string Id { get; set; }
        public string Devicename { get; set; }
        public string Command { get; set; }
        public ICollection<User> Owners { get; set; }
    }
}
