using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobeye_API.Dtos
{
    public class AlarmUpdateDto
    {
        public string Confirmed_Denied { get; set; }
        public DateTime Confirmed_at { get; set; }
    }
}
