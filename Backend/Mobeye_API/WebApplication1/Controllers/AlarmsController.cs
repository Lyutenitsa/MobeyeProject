using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobeye_API.Data;
using Mobeye_API.Dtos;
using Mobeye_API.Models;

namespace Mobeye_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlarmsController : ControllerBase
    {
        private readonly IAlarm _alarmRepo;
        private readonly IMapper _mapper;

        public AlarmsController(IAlarm alarmRepo, IMapper mapper)
        {
            _alarmRepo = alarmRepo;
            _mapper = mapper;
        }
        // we get the alarm from the mobeye's api
        [HttpPost]
        public ActionResult<AlarmReadDto> CreateAlarm(AlarmCreateDto alarmCreateDto)
        {
            var alarmModel = _mapper.Map<Alarm>(alarmCreateDto);
            _alarmRepo.CreateAlarm(alarmModel);
            _alarmRepo.SaveChanges();

            var alarmReadDto = _mapper.Map<AlarmReadDto>(alarmModel);
            return CreatedAtAction(nameof(GetAlarmById), new { id = alarmReadDto.Id }, alarmReadDto);
        }
        [HttpGet("{id}", Name = "GetAlarmById")]
        public ActionResult<AlarmReadDto> GetAlarmById(Guid id)
        {
            var alarm = _alarmRepo.GetAlarmById(id);
            if (alarm != null)
            {
                return Ok(_mapper.Map<AlarmReadDto>(alarm));
            }
            return NotFound();
        }
        [HttpGet("last")]
        public ActionResult<AlarmReadDto> GetAlarm()
        {
            var alarm = _alarmRepo.GetAlarm();
            if (alarm != null)
            {
                return Ok(_mapper.Map<AlarmReadDto>(alarm));
            }
            return NotFound();
        }
        [HttpGet]
        public ActionResult<IEnumerable<AlarmReadDto>> GetAllAlarms()
        {
            var alarms = _alarmRepo.GetAllAlarms();
            var model = _mapper.Map<IEnumerable<AlarmReadDto>>(alarms);

            return Ok(model);
        }
        [HttpGet("devicename/{devicename}")]
        public ActionResult<IEnumerable<AlarmReadDto>> GetAllAlarmsByDevicename(string deviceName)
        {
            var alarms = _alarmRepo.GetAllAlarmsByDevicename(deviceName);
            var model = _mapper.Map<IEnumerable<AlarmReadDto>>(alarms);

            return Ok(model);
        }
        [HttpGet("location/{location}")]
        public ActionResult<IEnumerable<AlarmReadDto>> GetAllAlarmsByLocation(string location)
        {
            var alarms = _alarmRepo.GetAllAlarmsByLocation(location);
            var model = _mapper.Map<IEnumerable<AlarmReadDto>>(alarms);

            return Ok(model);
        }
        [HttpGet("priority/{priority}")]
        public ActionResult<IEnumerable<AlarmReadDto>> GetAllAlarmsByPriority(int priority)
        {
            var alarms = _alarmRepo.GetAllAlarmsByPriority(priority);
            var model = _mapper.Map<IEnumerable<AlarmReadDto>>(alarms);

            return Ok(model);
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteAlarm(Guid id)
        {
            var alarmModelFromRepo = _alarmRepo.GetAlarmById(id);
            if (alarmModelFromRepo == null)
            {
                return NotFound();
            }
            _alarmRepo.DeleteAlarm(id);
            _alarmRepo.SaveChanges();

            return NoContent();
        }
        [HttpPut("{id}")]
        public ActionResult<AlarmReadDto> UpdateAlarm(Guid id, AlarmUpdateDto alarmUpdateDto)
        {
            var alarmModelFromRepo = _alarmRepo.GetAlarmById(id);
            if (alarmModelFromRepo == null)
            {
                return NotFound();
            }
            //maps the alarm object with the new value to the alarm object that has been created, and updates with the new changes
            _mapper.Map(alarmUpdateDto, alarmModelFromRepo);
            _alarmRepo.UpdateAlarm(alarmModelFromRepo);
            _alarmRepo.SaveChanges();

            return NoContent();
        }

    }
}
