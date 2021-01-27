using MobeyeApplication.MobeyeRESTClient.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobeyeApplication.MobeyeRESTClient.Data
{
    public interface IAlarm
    {
        Task<IEnumerable<Alarm>> GetAllAlarms();
        Task GetAlarmById(Guid id);
        Task UpdateAlarm(Alarm alarm);
        Task<List<Alarm>> GetAllAlarmsByPriority(int priority);

    }
}
