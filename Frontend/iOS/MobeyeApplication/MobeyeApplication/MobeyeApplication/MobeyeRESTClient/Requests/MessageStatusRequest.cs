using System;
using System.Collections.Generic;
using System.Text;

namespace MobeyeApplication.MobeyeRESTClient.Requests
{
    public class MessageStatusRequest
    {
        // unique id of the phone of the user -> basically the IMEI
        public string PhoneId { get; set; }
        // id of the message send by the portal (alarm) for which the status(confirmed/denied) is updated
        public int UniqueMessageId { get; set; }
        //status of the message (confirmed/denied)
        public string Response { get; set; }
        //private key of the user
        public string PrivateKey { get; set; }
    }
}
