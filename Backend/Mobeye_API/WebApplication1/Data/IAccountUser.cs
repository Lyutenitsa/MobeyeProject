using Mobeye_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Mobeye_API.Data
{
    public interface IAccountUser
    {
        // The IAccount Interface defines the functionality that the account user would have
        /*  void Register(string phoneIMEI, string registrationCodeSMS);
          User CheckAuthorization(string phoneIMEI, string registrationPrivateKey, string role, IEnumerable<String> devices, string authPrivateKey);
          void OpenDoor(string phoneIMEI, string authPrivateKey, string deviceID, string command);
          void SendMessage(string phoneIMEI, string authPrivateKey, string messageId, string status, DateTime date);
          void MessageStatus(string phoneIMEI, string authPrivateKey, string messageId, string status);*/
        void CreateUser(AccountUser user);
        void UpdateUser(AccountUser user);
        User GetUserByIMEI(string phoneIMEI);
        User GetUserByIMEIAndPrivateKey(string phoneIMEI, string authPrivateKey);
        User GetUserById(Guid id);
        bool SaveChanges();
        IEnumerable<User> GetAllUsers(string role);




    }
}
