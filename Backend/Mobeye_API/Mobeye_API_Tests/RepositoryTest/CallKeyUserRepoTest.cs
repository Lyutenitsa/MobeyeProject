using Microsoft.EntityFrameworkCore;
using Mobeye_API.Data;
using Mobeye_API.Models;
using Mobeye_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Mobeye_API_Tests.RepositoryTest
{
    public class CallKeyUserRepoTest :IDisposable
    {
        DbContextOptionsBuilder<ApplicationDBContext> optionsBuilder;
        ApplicationDBContext dBContext;
        CallKeyUserRepo callKeyRepo;

        public CallKeyUserRepoTest()
        {
            optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
            optionsBuilder.UseInMemoryDatabase("IntegrationTestInMemoDb");
            dBContext = new ApplicationDBContext(optionsBuilder.Options);

            callKeyRepo = new CallKeyUserRepo(dBContext);
        }
        public void Dispose()
        {
            optionsBuilder = null;
            foreach (var callKeyUser in dBContext.CallKeyUsers)
            {
                dBContext.CallKeyUsers.Remove(callKeyUser);
            }
            dBContext.SaveChanges();
            dBContext.Dispose();
            callKeyRepo = null;
        }
        [Fact]
        public void CallKeyUser_RegisterTest()
        {
            var phoneIMEI = "IMEI";
            var regCodeSMS = "sms";
            callKeyRepo.Register(phoneIMEI, regCodeSMS);
            var result = dBContext.CallKeyUsers;
            foreach(CallKeyUser user in result)
            {
                if (user.PhoneIMEI == phoneIMEI && user.SMSCode == regCodeSMS)
                {
                    Assert.True(true);
                }
            }
        }
        [Fact]
        public void CallKeyUserRepo_CheckAuth()
        {
            var callKeyUser = new CallKeyUser()
            {
                Id = Guid.NewGuid(),
                PhoneIMEI = "123",
                SMSCode = "12345",
                RegistrationPrivateKey = "abcd",
                AuthPrivateKey = "safe",
                Role = "CallKey User",
                Devices = null
            };
            dBContext.Users.Add(callKeyUser);
            ICollection<Device> devices = callKeyUser.Devices;
            var result = callKeyRepo.CheckAuthorization(callKeyUser.Role, devices, callKeyUser.AuthPrivateKey);
            Assert.NotNull(result);
        }
    }
}
