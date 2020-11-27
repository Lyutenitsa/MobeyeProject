using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobeye_API.Models;

namespace Mobeye_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlarmsController : ControllerBase
    {
        // we get the alarm from the mobeye's api
        [HttpPost]
        public ActionResult<Alarm> CreateAlarm(Alarm alarm)
        {
            //dobavqme alarmata v inmemory bazata ili v bazata 
            // ili nz kakvo pravim s obekta :) 
            return Ok();
        }
    }
}
