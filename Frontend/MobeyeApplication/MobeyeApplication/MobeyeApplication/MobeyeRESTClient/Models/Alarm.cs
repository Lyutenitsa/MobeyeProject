using System;
using System.Collections.Generic;
using System.Text;

namespace MobeyeApplication.MobeyeRESTClient.Models
{
    public class Alarm
    {
        public Guid Id { get; set; }

        public string Devicename { get; set; }

        public string Location { get; set; }

        public string Alarmtext { get; set; }

        public string Set_Reset { get; set; }

        public int Priority { get; set; }

        public DateTime TimeOfAlarm { get; set; }
        public string Value { get; set; }

        public string MessageId { get; set; }

        public ICollection<User> Recipients { get; set; }

        public bool Escalation { get; set; }
        public string Confirmed_Denied { get; set; }
        public DateTime Confirmed_at { get; set; }
    }
}
