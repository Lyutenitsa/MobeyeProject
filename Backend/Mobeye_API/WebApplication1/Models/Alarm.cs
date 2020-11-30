using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mobeye_API.Models
{
    public class Alarm
    {
        public Alarm()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        [Required]
        public string Devicename { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Alarmtext { get; set; }
        [Required]
        public string Set_Reset { get; set; }
        [Required]
        public int Priority { get; set; }
        [Required]
        public DateTime TimeOfAlarm { get; set; }
        public string Value { get; set; }
        [Required]
        public string MessageId { get; set; }
        [Required]
        public ICollection<User> Recipients { get; set; }
        [Required]
        public bool Escalation { get; set; }
        public string Confirmed_Denied { get; set; }
        public DateTime Confirmed_at { get; set; }





    }
}
