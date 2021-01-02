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
    public class AccountUserRepoTest : IDisposable
    {
        //INTEGRATION TESTING
        DbContextOptionsBuilder<ApplicationDBContext> optionsBuilder;
        ApplicationDBContext dBContext;
        AccountUserRepo _accountUserRepo;

        public AccountUserRepoTest()
        {
            optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
            optionsBuilder.UseInMemoryDatabase("IntegrationTestInMemoDb");
            dBContext = new ApplicationDBContext(optionsBuilder.Options);

            _accountUserRepo = new AccountUserRepo(dBContext);
        }
        public void Dispose()
        {
            optionsBuilder = null;
            foreach (var accountUser in dBContext.AccountUsers)
            {
                dBContext.AccountUsers.Remove(accountUser);
            }
            dBContext.SaveChanges();
            dBContext.Dispose();
            _accountUserRepo = null;
        }
        [Fact]
        public void GetAccountUsersWithEmptyDB_ReturnsZeroItemsTest()
        {
            //Arrange
            //Act
            var result = _accountUserRepo.GetAllUsers("Account User");
            //Assert
            Assert.Empty(result);
        }
        [Fact]
        public void GetAccountUsersWithOneUserInTheDBTest()
        {
            //Arrange
            var accountUser = new AccountUser()
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
            dBContext.AccountUsers.Add(accountUser);
            dBContext.SaveChanges();
            //Act
            var result = _accountUserRepo.GetAllUsers("Account User");
            //Assert
            Assert.Single(result);
        }
        [Fact]
        public void GetAllAccountUsers_ReturnsCorrectTypeTest()
        {
            //Arrange
            //Act
            var result = _accountUserRepo.GetAllUsers("Account User");
            //Assert
            Assert.IsAssignableFrom<IEnumerable<User>>(result);
        }
        [Fact]
        public void GetAccountUserWithInvalidIdTest_ShouldReturnNull()
        {
            //Arrange
            //DB is empty, so any id would be invalid
            //Act
            var result = _accountUserRepo.GetUserById(Guid.NewGuid());
            //Assert
            Assert.Null(result);
        }
        [Fact]
        public void GetAccountUserById_ReturnsTheCorrectTypeTest()
        {
            //Arrange
            var accountUser = new AccountUser()
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
            dBContext.AccountUsers.Add(accountUser);
            dBContext.SaveChanges();
            var id = accountUser.Id;
            //Act
            var result = _accountUserRepo.GetUserById(id);
            //Assert
            Assert.IsType<AccountUser>(result);
        }
        [Fact]
        public void GetAccountUserById_ReturnsCorrectResourceType()
        {
            //Arrange
            var accountUser = new AccountUser()
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
            dBContext.AccountUsers.Add(accountUser);
            dBContext.SaveChanges();
            var id = accountUser.Id;
            //Act
            var result = _accountUserRepo.GetUserById(id);
            //Assert
            Assert.Equal(id, accountUser.Id);
        }
        [Fact]
        public void AddAccountUserTest()
        {
            //Arrange
            var accountUser = new AccountUser()
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
            var objCount = dBContext.AccountUsers.Count();
            //Act
            _accountUserRepo.CreateUser(accountUser);
            _accountUserRepo.SaveChanges();
            //Assert
            Assert.Equal(objCount + 1, dBContext.AccountUsers.Count());
        }

    }
}
