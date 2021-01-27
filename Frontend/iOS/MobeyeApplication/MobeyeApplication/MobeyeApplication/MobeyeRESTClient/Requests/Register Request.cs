using System;
using System.Collections.Generic;
using System.Text;

namespace MobeyeApplication.MobeyeRESTClient.Requests
{
    public class Register_Request
    {
        // unique id for the phone -> IMEI demek
        public string PhoneId { get; set; }
        // code that would be send by Mobeye via SMS
        public string Code { get; set; }
    }
}
