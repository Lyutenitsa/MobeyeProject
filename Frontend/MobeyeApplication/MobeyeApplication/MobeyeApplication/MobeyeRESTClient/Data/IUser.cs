using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobeyeApplication.MobeyeRESTClient.Data
{
    public interface IUser
    {
        Task Register(string IMEI, string smsCode); //post request
        Task CheckAuthorization(string IMEI, string registrationPrivateKey); // get request
        Task OpenDoor(string IMEI, string authPrivateKey, string deviceID, string command); //post request
        Task MessageStatus(string IMEI, string authPrivateKey, string messageID, string status, DateTime date); //post request
    }
}
