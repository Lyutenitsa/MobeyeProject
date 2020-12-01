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
        Alarm GetAlarmById(Guid id);
        IEnumerable<Alarm> GetAllAlarms();
        IEnumerable<Alarm> GetAllAlarmsByPriority(int priority);
        IEnumerable<Alarm> GetAllAlarmsByDevicename(string deviceName);
        IEnumerable<Alarm> GetAllAlarmsByLocation(string location);
        bool SaveChanges();
        void UpdateAlarm(Alarm alarm);
        void DeleteAlarm(Guid id);

    }
}
