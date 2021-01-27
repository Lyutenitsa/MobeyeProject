using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobeyeApplication.MobeyeRESTClient.Data
{
    public class UserManager
    {
        IUser userService;
        public UserManager(IUser service)
        {
            userService = service;
        }
        public Task Register(string IMEI, string smsCode)
        {
            return userService.Register(IMEI, smsCode);
        }
        public Task CheckAuthorization(string IMEI, string registrationPrivateKey)
        {
            return userService.CheckAuthorization(IMEI, registrationPrivateKey);
        }
        public Task OpenDoor(string IMEI, string authPrivateKey, string deviceId, string command)
        {
            return userService.OpenDoor(IMEI, authPrivateKey, deviceId, command);
        }
        public Task MessageStatus(string IMEI, string authPrivateKey, string messageId, string status, DateTime date)
        {
            return userService.MessageStatus(IMEI, authPrivateKey, messageId, status, date);
        }
    }
}
