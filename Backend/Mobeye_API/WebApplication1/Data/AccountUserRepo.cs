using Mobeye_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobeye_API.Data
{
    public class AccountUserRepo : IAccountUser
    {
        public User CheckAuthorization(string role, IEnumerable<string> devices, string authPrivateKey)
        {
            throw new NotImplementedException();
        }

        public void MessageStatus(string phoneIMEI, string authPrivateKey, string messageId, string status)
        {
            throw new NotImplementedException();
        }

        public void OpenDoor(string phoneIMEI, string authPrivateKey, string deviceID, string command)
        {
            throw new NotImplementedException();
        }

        public void Register(string phoneIMEI, string registrationCodeSMS)
        {
            AccountUser accountUser = new AccountUser();
            accountUser.PhoneIMEI = phoneIMEI;
        }

        public void SendMessage(Alarm alarm)
        {
            throw new NotImplementedException();
        }
    }
}
