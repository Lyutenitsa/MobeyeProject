using Mobeye_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobeye_API.Data
{
    public interface IContactUser
    {
        // The IContact Interface defines the functionality that the contact user would have
        void Register(string phoneIMEI, string registrationCodeSMS);
        User CheckAuthorization(string role, IEnumerable<Device> devices, string authPrivateKey);
        void SendMessage(Alarm alarm);
        void MessageStatus(string phoneIMEI, string authPrivateKey, string messageId, string status);
    }
}
