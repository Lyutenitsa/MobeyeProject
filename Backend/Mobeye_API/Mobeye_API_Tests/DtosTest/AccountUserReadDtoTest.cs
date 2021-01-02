using Mobeye_API.Dtos;
using Mobeye_API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Mobeye_API_Tests.DtosTest
{
    public class AccountUserReadDtoTest
    {
        private AccountUserReadDto _accountUser;
        public AccountUserReadDtoTest()
        {
            _accountUser = new AccountUserReadDto()
            {
                Id = Guid.NewGuid(),
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
            Assert.Equal("123", _accountUser.PhoneIMEI);
        }
        [Fact]
        public void SetPhoneIMEI()
        {
            _accountUser.PhoneIMEI = "987";
            Assert.Equal("987", _accountUser.PhoneIMEI);
        }
        [Fact]
        public void GetSMSCode()
        {
            Assert.Equal("12345", _accountUser.SMSCode);
        }
        [Fact]
        public void SetSMSCode()
        {
            _accountUser.SMSCode = "0000";
            Assert.Equal("0000", _accountUser.SMSCode);
        }
        [Fact]
        public void GetRegistrationPrivateKey()
        {
            Assert.Equal("abcd", _accountUser.RegistrationPrivateKey);
        }
        [Fact]
        public void SetRegistrationPrivateKey()
        {
            _accountUser.RegistrationPrivateKey = "qwert";
            Assert.Equal("qwert", _accountUser.RegistrationPrivateKey);
        }
        [Fact]
        public void GetAuthPrivateKey()
        {
            Assert.Equal("safe", _accountUser.AuthPrivateKey);
        }
        [Fact]
        public void SetAuthPrivateKey()
        {
            _accountUser.AuthPrivateKey = "safe1";
            Assert.Equal("safe1", _accountUser.AuthPrivateKey);
        }
        [Fact]
        public void GetRole()
        {
            Assert.Equal("Account User", _accountUser.Role);
        }
        [Fact]
        public void SetRole()
        {
            _accountUser.Role = "Contact User";
            Assert.Equal("Contact User", _accountUser.Role);
        }
        [Fact]
        public void GetDevices()
        {
            Assert.Null(_accountUser.Devices);
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
            _accountUser.Devices = allDevices;
            Assert.Equal(allDevices, _accountUser.Devices);

        }
        [Fact]
        public void GetAlarms()
        {
            Assert.Null(_accountUser.Alarms);
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
            _accountUser.Alarms = allAlarms;
            Assert.Equal(allAlarms, _accountUser.Alarms);
        }
        [Fact]
        public void IdTypeTest()
        {
            Assert.IsType<Guid>(_accountUser.Id);
        }
        [Fact]
        public void PhoneIMEITypeTest()
        {
            Assert.IsType<string>(_accountUser.PhoneIMEI);
        }
        [Fact]
        public void SMSCodeTypeTest()
        {
            Assert.IsType<string>(_accountUser.SMSCode);
        }
        [Fact]
        public void RegistrationPrivateKeyTypeTest()
        {
            Assert.IsType<string>(_accountUser.RegistrationPrivateKey);
        }
        [Fact]
        public void AuthPrivateKeyTypeTest()
        {
            Assert.IsType<string>(_accountUser.AuthPrivateKey);
        }
        [Fact]
        public void RoleTypeTest()
        {
            Assert.IsType<string>(_accountUser.Role);
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
            _accountUser.Devices = allDevices;
            Assert.IsAssignableFrom<ICollection<Device>>(_accountUser.Devices);
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
            _accountUser.Alarms = allAlarms;
            Assert.IsAssignableFrom<ICollection<Alarm>>(_accountUser.Alarms);

        }
    }
}
