using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobeye_API.Models;

namespace Mobeye_API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ContactUsersController : ControllerBase
    {
        [HttpGet("/alarm")]
        public ActionResult<Alarm> GetAlarm()
        {
            // get the last alarm from the in-memory/normal database/cache
            //return the last entry in the alarm table
            return Ok();
        }
    }
}
