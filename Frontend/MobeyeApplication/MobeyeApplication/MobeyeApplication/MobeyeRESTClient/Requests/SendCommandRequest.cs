using System;
using System.Collections.Generic;
using System.Text;

namespace MobeyeApplication.MobeyeRESTClient.Requests
{
    public class SendCommandRequest //for open door functionality -> for the call key user
    {
        // unique id of the phone (IMEI)
        public string PhoneId { get; set; }
        // the id of the device that needs to be controlled
        public string DeviceId { get; set; }
        // private key of the user
        public string PrivateKey { get; set; }
        // command for the device
        public string Command { get; set; }

        // This functionality would not have a seperate response class as it returns HTTP Codes;
    }
}
