using System;
using System.Collections.Generic;
using System.Text;

namespace MobeyeApplication.MobeyeRESTClient.Responses
{
    public class CheckAuthorizationResponse
    {
        // user role
        public string UserRole { get; set; }
        // the new private authorization key
        public string PrivateKey { get; set; }
        // the devices that the user may control
        public List<Device> Devices { get; set; }

    }
    public class Device
    {
        public int DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string CommandText { get; set; }
        public string Command { get; set; }
    }
}
