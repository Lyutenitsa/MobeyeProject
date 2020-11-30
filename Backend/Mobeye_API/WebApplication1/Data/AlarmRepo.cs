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

        public Alarm GetAlarm()
        {
            //gets the last alarm that was inserted in the table
            return _context.Alarms.LastOrDefault();
        }
        public IEnumerable<Alarm> GetAllAlarms()
        {
            return _context.Alarms.ToList();
        }
    }
}
