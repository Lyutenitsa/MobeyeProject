using Mobeye_API.Dtos;
using Mobeye_API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Mobeye_API_Tests.DtosTest
{
    public class CallKeyUserCreateDtoTest
    {
        private CallKeyUserCreateDto callKeyUser;

        public CallKeyUserCreateDtoTest()
        {
            callKeyUser = new CallKeyUserCreateDto()
            {
                PhoneIMEI = "753",
                SMSCode = "code",
                RegistrationPrivateKey = "key",
                AuthPrivateKey = "private",
                Role = "Call-Key User",
                Devices = null
            };
        }

        [Fact]
        public void GetPhoneIMEI()
        {
            Assert.Equal("753", callKeyUser.PhoneIMEI);
        }
        [Fact]
        public void SetPhoneIMEI()
        {
            callKeyUser.PhoneIMEI = "951";
            Assert.Equal("951", callKeyUser.PhoneIMEI);
        }
        [Fact]
        public void GetSMSCode()
        {
            Assert.Equal("code", callKeyUser.SMSCode);
        }
        [Fact]
        public void SetSMSCode()
        {
            callKeyUser.SMSCode = "123";
            Assert.Equal("123", callKeyUser.SMSCode);
        }
        [Fact]
        public void GetRegistrationPrivateKey()
        {
            Assert.Equal("key", callKeyUser.RegistrationPrivateKey);
        }
        [Fact]
        public void SetRegistrationPrvateKey()
        {
            callKeyUser.RegistrationPrivateKey = "new";
            Assert.Equal("new", callKeyUser.RegistrationPrivateKey);
        }
        [Fact]
        public void GetRole()
        {
            Assert.Equal("Call-Key User", callKeyUser.Role);
        }
        [Fact]
        public void SetRole()
        {
            callKeyUser.Role = "Contact User";
            Assert.Equal("Contact User", callKeyUser.Role);
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
            newDevice.Id = "nice";
            newDevice.Devicename = "door";
            newDevice.Command = "open";
            devices.Add(newDevice);
            ICollection<Device> allDevices = devices;
            callKeyUser.Devices = allDevices;
            Assert.Equal(allDevices, callKeyUser.Devices);
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
            Assert.IsType<string>(callKeyUser.RegistrationPrivateKey);
        }
        [Fact]
        public void AuthPrivateKeyTypeTest()
        {
            Assert.IsType<string>(callKeyUser.AuthPrivateKey);
        }
        [Fact]
        public void RoleTypeTest()
        {
            Assert.IsType<string>(callKeyUser.Role);
        }
        [Fact]
        public void DevicesTypeTest()
        {
            List<Device> devices = new List<Device>();
            Device newDevice = new Device();
            newDevice.Id = "nice";
            newDevice.Devicename = "door";
            newDevice.Command = "open";
            devices.Add(newDevice);
            ICollection<Device> allDevices = devices;
            callKeyUser.Devices = allDevices;
            Assert.IsAssignableFrom<ICollection<Device>>(callKeyUser.Devices);
        }
    }
}
