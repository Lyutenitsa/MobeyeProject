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

        public int MessageId { get; set; }
        //need to fix this when the authorization is made
        public ICollection<User> Recipients { get; set; }

        public bool Escalation { get; set; }
        // those fields are for message status -> if the user has confirmed/denied the alarm
        public string Confirmed_Denied { get; set; }
        public DateTime Confirmed_at { get; set; }
    }
}
