using Microsoft.EntityFrameworkCore;
using Mobeye_API.Models;
using Mobeye_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobeye_API.Data
{
    public class AccountUserRepo : IAccountUser
    {
        private readonly ApplicationDBContext _context;
        public AccountUserRepo(ApplicationDBContext context)
        {
            _context = context;
        }

        /* public User CheckAuthorization(string phoneIMEI, string registrationPrivateKey, string role, IEnumerable<string> devices, string authPrivateKey)
         {
             var user = _context.AccountUsers.FirstOrDefault(p => p.PhoneIMEI == phoneIMEI && p.RegistrationPrivateKey == registrationPrivateKey);
             if (user == null)
             {
                 throw new ArgumentNullException(nameof(user));
             }
             //OPTION 1
             user.Role = role;
             List<Device> ownedDevices = (List<Device>)devices;
             user.Devices = ownedDevices;
             user.AuthPrivateKey = authPrivateKey;
             _context.Update(user);
             SaveChanges();
             return user;
             //OPTION 2
             *//*_context.Entry(user).State = EntityState.Modified;
             user.Role = role;
             List<Device> ownedDevices = (List<Device>)devices;
             user.Devices = ownedDevices;
             user.AuthPrivateKey = authPrivateKey;
             _context.SaveChanges();*//*
         }*/

        public void CreateUser(AccountUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _context.AccountUsers.Add(user);
            SaveChanges();
        }

        public IEnumerable<User> GetAllUsers(string role)
        {
            return _context.Users.Where(p => p.Role == role).ToList();
        }

        public User GetUserById(Guid id)
        {
            return _context.Users.FirstOrDefault(p => p.Id == id);
        }

        public User GetUserByIMEI(string phoneIMEI)
        {
            return _context.Users.FirstOrDefault(p => p.PhoneIMEI == phoneIMEI);
        }

        public User GetUserByIMEIAndPrivateKey(string phoneIMEI, string authPrivateKey)
        {
            return _context.Users.FirstOrDefault(p => p.PhoneIMEI == phoneIMEI && p.AuthPrivateKey == authPrivateKey);
        }

        /*  public void MessageStatus(string phoneIMEI, string authPrivateKey, string messageId, string status)
          {
              var user = _context.AccountUsers.FirstOrDefault(p => p.PhoneIMEI == phoneIMEI && p.AuthPrivateKey == authPrivateKey);
              if (user == null)
              {
                  throw new ArgumentNullException(nameof(user));
              }
              var alarm = user.Alarms.FirstOrDefault(p => p.MessageId == messageId);
              alarm.Confirmed_Denied = status;
              alarm.Confirmed_at = DateTime.Now;
          }

          public void OpenDoor(string phoneIMEI, string authPrivateKey, string deviceID, string command)
          {
              var user = _context.AccountUsers.FirstOrDefault(p => p.PhoneIMEI == phoneIMEI && p.AuthPrivateKey == authPrivateKey);
              if (user == null)
              {
                  throw new ArgumentNullException(nameof(user));
              }
              var device = user.Devices.FirstOrDefault(p => p.Id == deviceID);
              device.Command = command;
              _context.Devices.Update(device);
              SaveChanges();

              //OPTION 2
              *//* _context.Entry(device).State = EntityState.Modified;
               device.Command = command;
               SaveChanges();*//*
          }

          public void Register(string phoneIMEI, string registrationCodeSMS)
          {  // post request to mobeye's api so that they can save the phoneIMEI to the specific user
             // when the user clicks log in after they have input the registration code

              var user = _context.AccountUsers.FirstOrDefault(p => p.SMSCode == registrationCodeSMS);
              if (user == null)
              {
                  throw new ArgumentNullException(nameof(user));
              }
              //OPTION 1
              user.PhoneIMEI = phoneIMEI;
              _context.AccountUsers.Update(user);
              SaveChanges();
              //OPTION 2
              *//*      _context.Entry(user).CurrentValues.SetValues(user.PhoneIMEI == phoneIMEI);
                    SaveChanges();*//*
              //OPTION 3
              *//*  _context.Entry(user).State = EntityState.Modified;
                user.PhoneIMEI = phoneIMEI;
                _context.SaveChanges();*//*

          }*/

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateUser(AccountUser user)
        {
            // the user is updated by the entity framework core
        }

        /* public void SendMessage(string phoneIMEI, string authPrivateKey, string messageId, string status, DateTime date)
         {
             var user = _context.AccountUsers.FirstOrDefault(p => p.PhoneIMEI == phoneIMEI && p.AuthPrivateKey == authPrivateKey);
             if (user == null)
             {
                 throw new ArgumentNullException(nameof(user));
             }
             var alarm = user.Alarms.FirstOrDefault(p => p.MessageId == messageId);
             alarm.Confirmed_Denied = status;
             alarm.Confirmed_at = date;
             _context.Alarms.Update(alarm);
             SaveChanges();

             //OPTION 2
             _context.Entry(alarm).State = EntityState.Modified;
             alarm.Confirmed_Denied = status;
             alarm.Confirmed_at = date;
             SaveChanges();
         }*/
    }
}
