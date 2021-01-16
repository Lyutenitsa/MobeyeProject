using Microsoft.EntityFrameworkCore;
using Mobeye_API.Data;
using Mobeye_API.Models;
using Mobeye_API.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Mobeye_API_Tests.RepositoryTest
{
    public class ContactUserRepoTest : IDisposable
    {
        DbContextOptionsBuilder<ApplicationDBContext> optionsBuilder;
        ApplicationDBContext dBContext;
        ContactUserRepo contactUserRepo;

        public ContactUserRepoTest()
        {
            optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
            optionsBuilder.UseInMemoryDatabase("IntegrationTestInMemoDb");
            dBContext = new ApplicationDBContext(optionsBuilder.Options);

            contactUserRepo = new ContactUserRepo(dBContext);
        }
        public void Dispose()
        {
            optionsBuilder = null;
            foreach(var contactUser in dBContext.ContactUsers)
            {
                dBContext.ContactUsers.Remove(contactUser);
            }
            dBContext.SaveChanges();
            dBContext.Dispose();
            contactUserRepo = null;
        }
        [Fact]
        public void ContactUserRepo_CheckAuth()
        {
            var contactUser = new ContactUser()
            {
                Id = Guid.NewGuid(),
                PhoneIMEI = "123",
                SMSCode = "12345",
                RegistrationPrivateKey = "abcd",
                AuthPrivateKey = "safe",
                Role = "CallKey User",
                Devices = null
            };
            dBContext.Users.Add(contactUser);
            ICollection<Device> devices = contactUser.Devices;
            var result = contactUserRepo.CheckAuthorization(contactUser.Role, devices, contactUser.AuthPrivateKey);
            Assert.NotNull(result);
        }
        [Fact]
        public void ContactUser_RegisterTest()
        {
            var phoneIMEI = "IMEI";
            var regCodeSMS = "sms";
            contactUserRepo.Register(phoneIMEI, regCodeSMS);
            var result = dBContext.ContactUsers;
            foreach (ContactUser user in result)
            {
                if (user.PhoneIMEI == phoneIMEI && user.SMSCode == regCodeSMS)
                {
                    Assert.True(true);
                }
            }
        }
    }
}
