using System;
using System.Collections.Generic;
using System.Text;

namespace MobeyeApplication.MobeyeRESTClient.JSON_objects
{
    class RegPhone
    {
        public string phoneID;
        public string code;

        public RegPhone(string phoneID, string code)
        {
            this.phoneID = phoneID;
            this.code = code;
        }
    }
}
