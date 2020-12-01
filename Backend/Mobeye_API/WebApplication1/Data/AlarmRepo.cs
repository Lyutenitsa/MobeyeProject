using Mobeye_API.Models;
using Mobeye_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobeye_API.Data
{
    public class AlarmRepo : IAlarm
    {
        private readonly ApplicationDBContext _context;

        public AlarmRepo(ApplicationDBContext context)
        {
            _context = context;
        }
        public void CreateAlarm(Alarm alarm)
        {
            if (alarm == null)
            {
                throw new ArgumentNullException(nameof(alarm));
            }
            _context.Alarms.Add(alarm);
        }

        public void DeleteAlarm(Guid id)
        {
            var alarm = _context.Alarms.Find(id);
            if (alarm == null)
            {
                throw new ArgumentNullException(nameof(alarm));
            }
            _context.Alarms.Remove(alarm);
            _context.SaveChanges();
        }

        public Alarm GetAlarm()
        {
            //gets the last alarm that was inserted in the table
            return _context.Alarms.LastOrDefault();
        }

        public Alarm GetAlarmById(Guid id)
        {
            return _context.Alarms.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Alarm> GetAllAlarms()
        {
            return _context.Alarms.ToList();
        }

        public IEnumerable<Alarm> GetAllAlarmsByDevicename(string deviceName)
        {
            return _context.Alarms.Where(p => p.Devicename == deviceName).ToList();
        }

        public IEnumerable<Alarm> GetAllAlarmsByLocation(string location)
        {
            return _context.Alarms.Where(p => p.Location == location).ToList();
        }

        public IEnumerable<Alarm> GetAllAlarmsByPriority(int priority)
        {
            return _context.Alarms.Where(p => p.Priority == priority).ToList();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateAlarm(Alarm alarm)
        {
            //The update method is being taken care of by the DBContext, however since this class implements
            // the IAlarm interface, we need to implement it, but do nothing at all :)
        }
    }
}
