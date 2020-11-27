using Mobeye_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobeye_API.Data
{
    public interface ICallKeyUser
    {
        // The ICallKeyUser Interface defines the functionality that the call-key user would have
        void Register(string phoneIMEI, string registrationCodeSMS);
        User CheckAuthorization(string role, IEnumerable<String> devices, string authPrivateKey);
        void OpenDoor(string phoneIMEI, string authPrivateKey, string deviceID, string command);
    }
}
