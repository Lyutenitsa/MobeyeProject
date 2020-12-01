using Microsoft.EntityFrameworkCore;
using Mobeye_API.Data;
using Mobeye_API.Models;
using Mobeye_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Mobeye_API_Tests.RepositoryTest
{
    public class AlarmRepoTest : IDisposable
    {
        // INTEGRATION TESTING
        DbContextOptionsBuilder<ApplicationDBContext> optionsBuilder;
        ApplicationDBContext dBContext;
        AlarmRepo _alarmRepo;

        public AlarmRepoTest()
        {
            optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
            optionsBuilder.UseInMemoryDatabase("IntegrationTestInMemoDb");
            dBContext = new ApplicationDBContext(optionsBuilder.Options);

            _alarmRepo = new AlarmRepo(dBContext);
        }
        public void Dispose()
        {
            optionsBuilder = null;
            foreach (var alarm in dBContext.Alarms)
            {
                dBContext.Alarms.Remove(alarm);
            }
            dBContext.SaveChanges();
            dBContext.Dispose();
            _alarmRepo = null;
        }

        [Fact]
        public void GetAlarmsWithEmptyDB_ReturnsZeroItemsTest()
        {
            //Arrange
            //Act
            var result = _alarmRepo.GetAllAlarms();
            //Assert
            Assert.Empty(result);
        }
        [Fact]
        public void GetAlarmsWithOneAlarmInTheDBTest()
        {
            //Arrange
            var alarm = new Alarm()
            {
                Id = Guid.NewGuid(),
                Devicename = "SmokeDetector",
                Location = "Eindhoven",
                Alarmtext = "Smoke has been detected",
                Set_Reset = "Set",
                Priority = 1,
                TimeOfAlarm = DateTime.Today,
                Value = "1.2",
                MessageId = "1",
                Recipients = null,
                Escalation = false,
                Confirmed_Denied = "Confirmed",
                Confirmed_at = DateTime.Today
            };
            dBContext.Alarms.Add(alarm);
            dBContext.SaveChanges();
            //Act
            var result = _alarmRepo.GetAllAlarms();
            //Assert
            Assert.Single(result);
        }
        [Fact]
        public void GetAllAlarmsTest()
        {
            //Arrange
            var alarm1 = new Alarm()
            {
                Id = Guid.NewGuid(),
                Devicename = "SmokeDetector",
                Location = "Eindhoven",
                Alarmtext = "Smoke has been detected",
                Set_Reset = "Set",
                Priority = 1,
                TimeOfAlarm = DateTime.Today,
                Value = "1.2",
                MessageId = "1",
                Recipients = null,
                Escalation = false,
                Confirmed_Denied = "Confirmed",
                Confirmed_at = DateTime.Today
            };
            var alarm2 = new Alarm()
            {
                Id = Guid.NewGuid(),
                Devicename = "SmokeDetector",
                Location = "Eindhoven",
                Alarmtext = "Smoke has been detected",
                Set_Reset = "Set",
                Priority = 1,
                TimeOfAlarm = DateTime.Today,
                Value = "1.2",
                MessageId = "1",
                Recipients = null,
                Escalation = false,
                Confirmed_Denied = "Confirmed",
                Confirmed_at = DateTime.Today
            };
            dBContext.Alarms.Add(alarm1);
            dBContext.Alarms.Add(alarm2);
            dBContext.SaveChanges();
            //Act
            var result = _alarmRepo.GetAllAlarms();
            //Assert
            Assert.Equal(2, result.Count());
        }
        [Fact]
        public void GetAllAlarms_ReturnsCorrectTypeTest()
        {
            //Arrange
            //Act
            var result = _alarmRepo.GetAllAlarms();
            //Assert
            Assert.IsAssignableFrom<IEnumerable<Alarm>>(result);
        }
        [Fact]
        public void GetAlarmWithInvalidIdTest_ShouldReturnNull()
        {
            //Arrange
            //DB is empty so any id would be invalid
            //Act
            var result = _alarmRepo.GetAlarmById(Guid.NewGuid());
            //Assert
            Assert.Null(result);
        }
        [Fact]
        public void GetAlarmById_ReturnsTheCorrectTypeTest()
        {
            //Arrange
            var alarm = new Alarm()
            {
                Id = Guid.NewGuid(),
                Devicename = "SmokeDetector",
                Location = "Eindhoven",
                Alarmtext = "Smoke has been detected",
                Set_Reset = "Set",
                Priority = 1,
                TimeOfAlarm = DateTime.Today,
                Value = "1.2",
                MessageId = "1",
                Recipients = null,
                Escalation = false,
                Confirmed_Denied = "Confirmed",
                Confirmed_at = DateTime.Today
            };
            dBContext.Alarms.Add(alarm);
            dBContext.SaveChanges();
            var id = alarm.Id;

            //Act
            var result = _alarmRepo.GetAlarmById(id);
            //Assert
            Assert.IsType<Alarm>(result);
        }
        [Fact]
        public void GetAlarmById_ReturnsCorrectResourceTest()
        {
            //Arrange
            var alarm = new Alarm()
            {
                Id = Guid.NewGuid(),
                Devicename = "SmokeDetector",
                Location = "Eindhoven",
                Alarmtext = "Smoke has been detected",
                Set_Reset = "Set",
                Priority = 1,
                TimeOfAlarm = DateTime.Today,
                Value = "1.2",
                MessageId = "1",
                Recipients = null,
                Escalation = false,
                Confirmed_Denied = "Confirmed",
                Confirmed_at = DateTime.Today
            };
            dBContext.Alarms.Add(alarm);
            dBContext.SaveChanges();
            var id = alarm.Id;
            //Act
            var result = _alarmRepo.GetAlarmById(id);
            //Arrange
            Assert.Equal(id, result.Id);
        }
        [Fact]
        public void AddAlarmTest()
        {
            //Arrange
            var alarm = new Alarm()
            {
                Id = Guid.NewGuid(),
                Devicename = "SmokeDetector",
                Location = "Eindhoven",
                Alarmtext = "Smoke has been detected",
                Set_Reset = "Set",
                Priority = 1,
                TimeOfAlarm = DateTime.Today,
                Value = "1.2",
                MessageId = "1",
                Recipients = null,
                Escalation = false,
                Confirmed_Denied = "Confirmed",
                Confirmed_at = DateTime.Today
            };
            var objCount = dBContext.Alarms.Count();
            //Act
            _alarmRepo.CreateAlarm(alarm);
            _alarmRepo.SaveChanges();
            //Assert
            Assert.Equal(objCount + 1, dBContext.Alarms.Count());
        }
        [Fact]
        public void DeleteAlarmTest()
        {
            //Arrange
            var alarm = new Alarm()
            {
                Id = Guid.NewGuid(),
                Devicename = "SmokeDetector",
                Location = "Eindhoven",
                Alarmtext = "Smoke has been detected",
                Set_Reset = "Set",
                Priority = 1,
                TimeOfAlarm = DateTime.Today,
                Value = "1.2",
                MessageId = "1",
                Recipients = null,
                Escalation = false,
                Confirmed_Denied = "Confirmed",
                Confirmed_at = DateTime.Today
            };
            dBContext.Alarms.Add(alarm);
            dBContext.SaveChanges();
            var objCount = dBContext.Alarms.Count();
            var id = alarm.Id;
            //Act
            _alarmRepo.DeleteAlarm(id);
            _alarmRepo.SaveChanges();
            //Assert
            Assert.Equal(objCount - 1, dBContext.Alarms.Count());
        }
        [Fact]
        public void AddNullAlarmTest_ThrowsException()
        {
            //Arrange
            Alarm alarm = null;
            //Act&Assert
            Assert.Throws<ArgumentNullException>(() => _alarmRepo.CreateAlarm(alarm));
        }
        [Fact]
        public void DeleteNullAlarmTest_ThrowsException()
        {
            //Arrange
            Alarm alarm = new Alarm();
            //Act&Assert
            Assert.Throws<ArgumentNullException>(() => _alarmRepo.DeleteAlarm(alarm.Id));
        }
        [Fact]
        public void GetAllAlarmsByDevicename_WithInvalidDevicenameTest()
        {
            //Arrange
            //Db is empty so any devicename would be invalid
            var result = _alarmRepo.GetAllAlarmsByDevicename("Hello");
            //Assert
            Assert.Empty(result);
        }
        [Fact]
        public void GetAllAlarmsByLocation_WithInvalidLocationTest()
        {
            //Arrange
            //Db is empty so any location would be invalid
            var result = _alarmRepo.GetAllAlarmsByLocation("Sofia");
            //Assert
            Assert.Empty(result);
        }
        [Fact]
        public void GetAllAlarmsByPriority_WithInavlidPriority()
        {
            //Arrange
            //Db is empty so any priority would be invalid
            var result = _alarmRepo.GetAllAlarmsByPriority(1);
            //Assert
            Assert.Empty(result);
        }
        [Fact]
        public void GetAllAlarmsByDevicename_ReturnsCorrectTypeTest()
        {
            //Arrange
            var alarm = new Alarm()
            {
                Id = Guid.NewGuid(),
                Devicename = "SmokeDetector",
                Location = "Eindhoven",
                Alarmtext = "Smoke has been detected",
                Set_Reset = "Set",
                Priority = 1,
                TimeOfAlarm = DateTime.Today,
                Value = "1.2",
                MessageId = "1",
                Recipients = null,
                Escalation = false,
                Confirmed_Denied = "Confirmed",
                Confirmed_at = DateTime.Today
            };
            dBContext.Alarms.Add(alarm);
            dBContext.SaveChanges();
            //Act
            var result = _alarmRepo.GetAllAlarmsByDevicename(alarm.Devicename);
            //Assert
            Assert.IsAssignableFrom<IEnumerable<Alarm>>(result);
        }
        [Fact]
        public void GetAllAlarmsByLocation_ReturnsCorrectTypeTest()
        {
            //Arrange
            var alarm = new Alarm()
            {
                Id = Guid.NewGuid(),
                Devicename = "SmokeDetector",
                Location = "Eindhoven",
                Alarmtext = "Smoke has been detected",
                Set_Reset = "Set",
                Priority = 1,
                TimeOfAlarm = DateTime.Today,
                Value = "1.2",
                MessageId = "1",
                Recipients = null,
                Escalation = false,
                Confirmed_Denied = "Confirmed",
                Confirmed_at = DateTime.Today
            };
            dBContext.Alarms.Add(alarm);
            dBContext.SaveChanges();
            //Act
            var result = _alarmRepo.GetAllAlarmsByLocation(alarm.Location);
            //Assert
            Assert.IsAssignableFrom<IEnumerable<Alarm>>(result);
        }
        [Fact]
        public void GetAllAlarmsByPriority_ReturnsCorrectTypeTest()
        {
            //Arrange
            var alarm = new Alarm()
            {
                Id = Guid.NewGuid(),
                Devicename = "SmokeDetector",
                Location = "Eindhoven",
                Alarmtext = "Smoke has been detected",
                Set_Reset = "Set",
                Priority = 1,
                TimeOfAlarm = DateTime.Today,
                Value = "1.2",
                MessageId = "1",
                Recipients = null,
                Escalation = false,
                Confirmed_Denied = "Confirmed",
                Confirmed_at = DateTime.Today
            };
            dBContext.Alarms.Add(alarm);
            dBContext.SaveChanges();
            //Act
            var result = _alarmRepo.GetAllAlarmsByPriority(alarm.Priority);
            //Assert
            Assert.IsAssignableFrom<IEnumerable<Alarm>>(result);
        }
        [Fact]
        public void GetAlarm_ReturnsNullTest()
        {
            //Arrange
            //Db is empty so any alarm would be invalid
            //Act
            var result = _alarmRepo.GetAlarm();
            //Assert
            Assert.Null(result);
        }
        [Fact]
        public void GetAlarm_ReturnsCorrectResourceTest()
        {
            //Arrange
            var alarm1 = new Alarm()
            {
                Id = Guid.NewGuid(),
                Devicename = "SmokeDetector",
                Location = "Eindhoven",
                Alarmtext = "Smoke has been detected",
                Set_Reset = "Set",
                Priority = 1,
                TimeOfAlarm = DateTime.Today,
                Value = "1.2",
                MessageId = "1",
                Recipients = null,
                Escalation = false,
                Confirmed_Denied = "Confirmed",
                Confirmed_at = DateTime.Today
            };
            var alarm2 = new Alarm()
            {
                Id = Guid.NewGuid(),
                Devicename = "SmokeDetector",
                Location = "Eindhoven",
                Alarmtext = "Smoke has been detected",
                Set_Reset = "Set",
                Priority = 1,
                TimeOfAlarm = DateTime.Today,
                Value = "1.2",
                MessageId = "1",
                Recipients = null,
                Escalation = false,
                Confirmed_Denied = "Confirmed",
                Confirmed_at = DateTime.Today
            };
            dBContext.Alarms.Add(alarm1);
            dBContext.Alarms.Add(alarm2);
            dBContext.SaveChanges();
            //Act
            var result = _alarmRepo.GetAlarm();
            //Assert
            Assert.Equal(alarm2, result);
        }
        [Fact]
        public void GetAlarm_ReturnsCorrectTypeTest()
        {
            var alarm = new Alarm()
            {
                Id = Guid.NewGuid(),
                Devicename = "SmokeDetector",
                Location = "Eindhoven",
                Alarmtext = "Smoke has been detected",
                Set_Reset = "Set",
                Priority = 1,
                TimeOfAlarm = DateTime.Today,
                Value = "1.2",
                MessageId = "1",
                Recipients = null,
                Escalation = false,
                Confirmed_Denied = "Confirmed",
                Confirmed_at = DateTime.Today
            };
            dBContext.Alarms.Add(alarm);
            dBContext.SaveChanges();
            //Act
            var result = _alarmRepo.GetAlarm();
            //Assert
            Assert.IsType<Alarm>(result);
        }




    }
}
