using Mobeye_API.Models;
using Mobeye_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobeye_API.Data
{
    public class ContactUserRepo : IContactUser
    {
        private readonly ApplicationDBContext _context;
        public ContactUserRepo(ApplicationDBContext context)
        {
            _context = context;
        }
        public User CheckAuthorization(string role, IEnumerable<string> devices, string authPrivateKey)
        {
            if (role != "Contact User" && authPrivateKey == null)
            {
                throw new ArgumentNullException();
            }
            return _context.Users.FirstOrDefault(p => p.Role == role && p.Devices == devices && p.AuthPrivateKey == authPrivateKey);
        }

        public void MessageStatus(string phoneIMEI, string authPrivateKey, string messageId, string status)
        {
            throw new NotImplementedException();
        }

        public void Register(string phoneIMEI, string registrationCodeSMS)
        {
            if (phoneIMEI == null && registrationCodeSMS == null)
            {
                throw new ArgumentNullException();
            }
            ContactUser u = new ContactUser
            {
                Role = "Contact User",
                PhoneIMEI = phoneIMEI,
                SMSCode = registrationCodeSMS
            };
            _context.ContactUsers.Add(u);
        }

        public void SendMessage(Alarm alarm)
        {
            throw new NotImplementedException();
        }
    }
}
