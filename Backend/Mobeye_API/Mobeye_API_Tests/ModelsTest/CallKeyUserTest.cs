using Mobeye_API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Mobeye_API_Tests.ModelsTest
{
    public class CallKeyUserTest
    {
        private CallKeyUser callKeyUser;

        public CallKeyUserTest()
        {
            callKeyUser = new CallKeyUser()
            {
                Id = Guid.NewGuid(),
                PhoneIMEI = "123",
                SMSCode = "abc",
                RegistrationPrivateKey = "qwerty",
                AuthPrivateKey = "key",
                Role = "CallKey User",
                Devices = null
            };
        }
        [Fact]
        public void GetPhoneIMEI()
        {
            Assert.Equal("123", callKeyUser.PhoneIMEI);
        }
        [Fact]
        public void SetPhoneIMEI()
        {
            callKeyUser.PhoneIMEI = "789";
            Assert.Equal("789", callKeyUser.PhoneIMEI);
        }
        [Fact]
        public void GetSMSCode()
        {
            Assert.Equal("abc", callKeyUser.SMSCode);
        }
        [Fact]
        public void SetSMSCode()
        {
            callKeyUser.SMSCode = "lol";
            Assert.Equal("lol", callKeyUser.SMSCode);
        }
        [Fact]
        public void GetRegistrationPrivateKey()
        {
            Assert.Equal("qwerty", callKeyUser.RegistrationPrivateKey);
        }
        [Fact]
        public void SetRegistrationPrivateKey()
        {
            callKeyUser.RegistrationPrivateKey = "wasd";
            Assert.Equal("wasd", callKeyUser.RegistrationPrivateKey);
        }
        [Fact]
        public void GetAuthPrivateKey()
        {
            Assert.Equal("key", callKeyUser.AuthPrivateKey);
        }
        [Fact]
        public void SetAuthPrivateKey()
        {
            callKeyUser.AuthPrivateKey = "sup";
            Assert.Equal("sup", callKeyUser.AuthPrivateKey);
        }
        [Fact]
        public void GetRole()
        {
            Assert.Equal("CallKey User", callKeyUser.Role);
        }
        [Fact]
        public void SetRole()
        {
            callKeyUser.Role = "Account User";
            Assert.Equal("Account User", callKeyUser.Role);
        }
        [Fact]
        public void GetDevices()
        {
            Assert.Null(callKeyUser.Devices);
        }
        [Fact]
        public void SetDevices()
        {
            List<Device> devices = new List<Device>();
            Device newDevice = new Device();
            newDevice.Id = "door";
            newDevice.Devicename = "minecraftDoor";
            newDevice.Command = "open";
            devices.Add(newDevice);
            ICollection<Device> allDevices = devices;
            callKeyUser.Devices = allDevices;
            Assert.Equal(allDevices, callKeyUser.Devices);
        }
        [Fact]
        public void IdTypeTest()
        {
            Assert.IsType<Guid>(callKeyUser.Id);
        }
        [Fact]
        public void PhoneIMEITypeTest()
        {
            Assert.IsType<string>(callKeyUser.PhoneIMEI);
        }
        [Fact]
        public void SMSCodeTypeTest()
        {
            Assert.IsType<string>(callKeyUser.SMSCode);
        }
        [Fact]
        public void RegistrationPrivateKeyTypeTest()
        {
            Assert.IsType<string>(callKeyUser.AuthPrivateKey);
        }
        [Fact]
        public void AuthPrivateKeyTest()
        {
            Assert.IsType<string>(callKeyUser.AuthPrivateKey);
        }
        [Fact]
        public void RoleTypeTest()
        {
            Assert.IsType<string>(callKeyUser.Role);
        }
        [Fact]
        public void DeviceTypeTest()
        {
            List<Device> devices = new List<Device>();
            Device newDevice = new Device();
            newDevice.Id = "door";
            newDevice.Devicename = "minecraftDoor";
            newDevice.Command = "open";
            devices.Add(newDevice);
            ICollection<Device> allDevices = devices;
            callKeyUser.Devices = allDevices;
            Assert.IsAssignableFrom<ICollection<Device>>(callKeyUser.Devices);
        }
    }
}
