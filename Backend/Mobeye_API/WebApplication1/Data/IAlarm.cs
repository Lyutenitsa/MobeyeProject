using Mobeye_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobeye_API.Data
{
    public interface IAlarm
    {
        void CreateAlarm(Alarm alarm);
        Alarm GetAlarm();
        IEnumerable<Alarm> GetAllAlarms();

    }
}
