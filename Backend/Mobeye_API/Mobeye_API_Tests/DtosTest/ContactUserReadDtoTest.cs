using Mobeye_API.Dtos;
using Mobeye_API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Mobeye_API_Tests.DtosTest
{
    public class ContactUserReadDtoTest
    {
        private ContactUserReadDto contactUser;

        public ContactUserReadDtoTest()
        {
            contactUser = new ContactUserReadDto()
            {
                PhoneIMEI = "123",
                SMSCode = "12345",
                RegistrationPrivateKey = "abcd",
                AuthPrivateKey = "safe",
                Role = "Account User",
                Devices = null,
                Alarms = null
            };
        }
        [Fact]
        public void GetPhoneIMEI()
        {
            Assert.Equal("123", contactUser.PhoneIMEI);
        }
        [Fact]
        public void SetPhoneIMEI()
        {
            contactUser.PhoneIMEI = "987";
            Assert.Equal("987", contactUser.PhoneIMEI);
        }
        [Fact]
        public void GetSMSCode()
        {
            Assert.Equal("12345", contactUser.SMSCode);
        }
        [Fact]
        public void SetSMSCode()
        {
            contactUser.SMSCode = "0000";
            Assert.Equal("0000", contactUser.SMSCode);
        }
        [Fact]
        public void GetRegistrationPrivateKey()
        {
            Assert.Equal("abcd", contactUser.RegistrationPrivateKey);
        }
        [Fact]
        public void SetRegistrationPrivateKey()
        {
            contactUser.RegistrationPrivateKey = "qwert";
            Assert.Equal("qwert", contactUser.RegistrationPrivateKey);
        }
        [Fact]
        public void GetAuthPrivateKey()
        {
            Assert.Equal("safe", contactUser.AuthPrivateKey);
        }
        [Fact]
        public void SetAuthPrivateKey()
        {
            contactUser.AuthPrivateKey = "safe1";
            Assert.Equal("safe1", contactUser.AuthPrivateKey);
        }
        [Fact]
        public void GetRole()
        {
            Assert.Equal("Account User", contactUser.Role);
        }
        [Fact]
        public void SetRole()
        {
            contactUser.Role = "Contact User";
            Assert.Equal("Contact User", contactUser.Role);
        }
        [Fact]
        public void GetDevices()
        {
            Assert.Null(contactUser.Devices);
        }
        [Fact]
        public void SetDevices()
        {
            List<Device> devices = new List<Device>();
            Device newDevice = new Device();
            newDevice.Id = "hello";
            newDevice.Devicename = "alarmdetector";
            newDevice.Devicename = "open";
            devices.Add(newDevice);
            ICollection<Device> allDevices = devices;
            contactUser.Devices = allDevices;
            Assert.Equal(allDevices, contactUser.Devices);

        }
        [Fact]
        public void GetAlarms()
        {
            Assert.Null(contactUser.Alarms);
        }
        [Fact]
        public void SetAlarms()
        {
            List<Alarm> alarms = new List<Alarm>();
            var _alarm = new Alarm()
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
            alarms.Add(_alarm);
            ICollection<Alarm> allAlarms = alarms;
            contactUser.Alarms = allAlarms;
            Assert.Equal(allAlarms, contactUser.Alarms);
        }
        [Fact]
        public void PhoneIMEITypeTest()
        {
            Assert.IsType<string>(contactUser.PhoneIMEI);
        }
        [Fact]
        public void SMSCodeTypeTest()
        {
            Assert.IsType<string>(contactUser.SMSCode);
        }
        [Fact]
        public void RegistrationPrivateKeyTypeTest()
        {
            Assert.IsType<string>(contactUser.RegistrationPrivateKey);
        }
        [Fact]
        public void AuthPrivateKeyTypeTest()
        {
            Assert.IsType<string>(contactUser.AuthPrivateKey);
        }
        [Fact]
        public void RoleTypeTest()
        {
            Assert.IsType<string>(contactUser.Role);
        }
        [Fact]
        public void DevicesTypeTest()
        {
            List<Device> devices = new List<Device>();
            Device newDevice = new Device();
            newDevice.Id = "hello";
            newDevice.Devicename = "alarmdetector";
            newDevice.Devicename = "open";
            devices.Add(newDevice);
            ICollection<Device> allDevices = devices;
            contactUser.Devices = allDevices;
            Assert.IsAssignableFrom<ICollection<Device>>(contactUser.Devices);
        }
        [Fact]
        public void AlarmsTypeTest()
        {

            List<Alarm> alarms = new List<Alarm>();
            var _alarm = new Alarm()
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
            alarms.Add(_alarm);
            ICollection<Alarm> allAlarms = alarms;
            contactUser.Alarms = allAlarms;
            Assert.IsAssignableFrom<ICollection<Alarm>>(contactUser.Alarms);

        }
    }
}
