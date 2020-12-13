using MobeyeApplication.MobeyeRESTClient.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobeyeApplication.MobeyeRESTClient.Data
{
    public class AlarmManager
    {
        IAlarm alarmService;
        public AlarmManager(IAlarm service)
        {
            alarmService = service;
        }
        public Task<List<Alarm>> GetAllAlarms()
        {
            return alarmService.GetAllAlarms();
        }
        public Task GetTaskById(Guid id)
        {
            return alarmService.GetAlarmById(id);
        }
        public Task<List<Alarm>> GetAllAlarmsByPriority(int priority)
        {
            return alarmService.GetAllAlarmsByPriority(priority);
        }
        public Task UpdateAlarm(Alarm alarm)
        {
            return alarmService.UpdateAlarm(alarm);
        }
    }
}
