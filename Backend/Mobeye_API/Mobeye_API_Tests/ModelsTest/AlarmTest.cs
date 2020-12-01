using Mobeye_API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Mobeye_API_Tests.ModelsTest
{
    public class AlarmTest
    {
        private Alarm _alarm;

        public AlarmTest()
        {
            _alarm = new Alarm()
            {
                Id = Guid.NewGuid(),
                Devicename = "SmokeDetector",
                Location = "Eindhoven",
                Alarmtext = "Smoke has been detected",
                Set_Reset = "Set",
                Priority = 1,
                TimeOfAlarm = DateTime.Today,
                Value = "1.2",
                MessageId = "1",
                Recipients = null,
                Escalation = false,
                Confirmed_Denied = "Confirmed",
                Confirmed_at = DateTime.Today
            };
        }
        [Fact]
        public void GetDevicenameTest()
        {
            Assert.Equal("SmokeDetector", _alarm.Devicename);
        }
        [Fact]
        public void SetDevicenameTest()
        {
            _alarm.Devicename = "FireDec200";
            Assert.Equal("FireDec200", _alarm.Devicename);
        }
        [Fact]
        public void GetLocationTest()
        {
            Assert.Equal("Eindhoven", _alarm.Location);
        }
        [Fact]
        public void SetLocationTest()
        {
            _alarm.Location = "Sofia";
            Assert.Equal("Sofia", _alarm.Location);
        }
        [Fact]
        public void GetAlarmtextTest()
        {
            Assert.Equal("Smoke has been detected", _alarm.Alarmtext);
        }
        [Fact]
        public void SetAlarmtextTest()
        {
            _alarm.Alarmtext = "Fire!";
            Assert.Equal("Fire!", _alarm.Alarmtext);
        }
        [Fact]
        public void GetSet_ResetTest()
        {
            Assert.Equal("Set", _alarm.Set_Reset);
        }
        [Fact]
        public void SetSet_ResetTest()
        {
            _alarm.Set_Reset = "Reset";
            Assert.Equal("Reset", _alarm.Set_Reset);
        }
        [Fact]
        public void GetPriorityTest()
        {
            Assert.Equal(1, _alarm.Priority);
        }
        [Fact]
        public void SetPriorityTest()
        {
            _alarm.Priority = 0;
            Assert.Equal(0, _alarm.Priority);
        }
        [Fact]
        public void GetTimeOfAlarmTest()
        {
            Assert.Equal(DateTime.Today, _alarm.TimeOfAlarm);
        }
        [Fact]
        public void SetTimeOfAlarmTest()
        {
            _alarm.TimeOfAlarm = DateTime.Today.AddDays(2);
            Assert.Equal(DateTime.Today.AddDays(2), _alarm.TimeOfAlarm);
        }
        [Fact]
        public void GetValueTest()
        {
            Assert.Equal("1.2", _alarm.Value);
        }
        [Fact]
        public void SetValueTest()
        {
            _alarm.Value = "12.89";
            Assert.Equal("12.89", _alarm.Value);
        }
        [Fact]
        public void GetMessageIdTest()
        {
            Assert.Equal("1", _alarm.MessageId);
        }
        [Fact]
        public void SetMessageIdTest()
        {
            _alarm.MessageId = "2";
            Assert.Equal("2", _alarm.MessageId);
        }
        [Fact]
        public void GetRecipientsTest()
        {
            Assert.Null(_alarm.Recipients);
        }
        [Fact]
        public void SetRecipientsTest()
        {
            List<User> recipients = new List<User>();
            AccountUser recipient = new AccountUser();
            recipients.Add(recipient);
            ICollection<User> users = recipients;
            _alarm.Recipients = users;
            Assert.Equal(users, _alarm.Recipients);
        }
        [Fact]
        public void GetEscalationTest()
        {
            Assert.False(_alarm.Escalation);
        }
        [Fact]
        public void SetEscalationTest()
        {
            _alarm.Escalation = true;
            Assert.True(_alarm.Escalation);
        }
        [Fact]
        public void GetConfirmed_DeniedTest()
        {
            Assert.Equal("Confirmed", _alarm.Confirmed_Denied);
        }
        [Fact]
        public void SetConfirmed_DeniedTest()
        {
            _alarm.Confirmed_Denied = "Denied";
            Assert.Equal("Denied", _alarm.Confirmed_Denied);
        }
        [Fact]
        public void GetConfirmed_AtTest()
        {
            Assert.Equal(DateTime.Today, _alarm.Confirmed_at);
        }
        [Fact]
        public void SetConfirmed_AtTest()
        {
            _alarm.Confirmed_at = DateTime.Today.AddDays(2);
            Assert.Equal(DateTime.Today.AddDays(2), _alarm.Confirmed_at);
        }
        [Fact]
        public void IdTypeTest()
        {
            Assert.IsType<Guid>(_alarm.Id);
        }
        [Fact]
        public void DevicenameTypeTest()
        {
            Assert.IsType<string>(_alarm.Devicename);
        }
        [Fact]
        public void LocationTypeTest()
        {
            Assert.IsType<string>(_alarm.Location);
        }
        [Fact]
        public void AlarmtextTypeTest()
        {
            Assert.IsType<string>(_alarm.Alarmtext);
        }
        [Fact]
        public void SetRestTypeTest()
        {
            Assert.IsType<string>(_alarm.Set_Reset);
        }
        [Fact]
        public void PriorityTypeTest()
        {
            Assert.IsType<int>(_alarm.Priority);
        }
        [Fact]
        public void TimeOfAlarmTypeTest()
        {
            Assert.IsType<DateTime>(_alarm.TimeOfAlarm);
        }
        [Fact]
        public void ValueTypeTest()
        {
            Assert.IsType<string>(_alarm.Value);
        }
        [Fact]
        public void MessageIdTypeTest()
        {
            Assert.IsType<string>(_alarm.MessageId);
        }
        [Fact]
        public void RecipientsTypeTest()
        {
            List<User> recipients = new List<User>();
            AccountUser recipient = new AccountUser();
            recipients.Add(recipient);
            ICollection<User> users = recipients;
            _alarm.Recipients = users;
            Assert.IsAssignableFrom<ICollection<User>>(_alarm.Recipients);
        }
        [Fact]
        public void EscalationTypeTest()
        {
            Assert.IsType<bool>(_alarm.Escalation);
        }
        [Fact]
        public void ConfirmedDeniedTypeTest()
        {
            Assert.IsType<string>(_alarm.Confirmed_Denied);
        }
        [Fact]
        public void Confirmed_AtTypeTest()
        {
            Assert.IsType<DateTime>(_alarm.Confirmed_at);
        }
    }
}
