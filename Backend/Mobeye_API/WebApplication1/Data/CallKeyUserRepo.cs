using Microsoft.EntityFrameworkCore;
using Mobeye_API.Models;
using Mobeye_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobeye_API.Data
{
    public class CallKeyUserRepo : ICallKeyUser
    {
        private readonly ApplicationDBContext _context;
        public CallKeyUserRepo(ApplicationDBContext context)
        {
            _context = context;
        }

        public User CheckAuthorization(string role, IEnumerable<Device> devices, string authPrivateKey)
        {
            if (role != "CallKey User" && authPrivateKey == null)
            {
                throw new ArgumentNullException();
            }
            return _context.Users.FirstOrDefault(p => p.Role == role && p.Devices == devices && p.AuthPrivateKey == authPrivateKey);
        }

        public void OpenDoor(string phoneIMEI, string authPrivateKey, string deviceID, string command)
        {
            Device door = _context.Devices.FirstOrDefault(p => p.Id == deviceID);
            door.Command = command;
        }

        public void Register(string phoneIMEI, string registrationCodeSMS)
        {
            if(phoneIMEI == null && registrationCodeSMS == null)
            {
                throw new ArgumentNullException();
            }
            CallKeyUser u = new CallKeyUser
            {
                Role = "CallKey User",
                PhoneIMEI = phoneIMEI,
                SMSCode = registrationCodeSMS
            };
            _context.CallKeyUsers.Add(u);
        }
    }
}
