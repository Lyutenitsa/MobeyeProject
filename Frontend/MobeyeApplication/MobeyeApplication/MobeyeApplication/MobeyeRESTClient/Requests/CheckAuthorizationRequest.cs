using System;
using System.Collections.Generic;
using System.Text;

namespace MobeyeApplication.MobeyeRESTClient.Requests
{
    public class CheckAuthorizationRequest
    {
        //unique id of the phone -> IMEI demek
        public string PhoneId { get; set; }
        // first private key that was send with the registration request
        public string PrivateKey { get; set; }
    }
}
