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
    public class AccountUsersController : ControllerBase
    {
        private readonly IAccountUser _accountUserRepo;
        private readonly IMapper _mapper;

        public AccountUsersController(IAccountUser accountUser, IMapper mapper)
        {
            _accountUserRepo = accountUser;
            _mapper = mapper;
        }
        //we get the users from mobeye's api but to simulate the real thing, we need this method
        [HttpPost]
        public ActionResult<AccountUserReadDto> CreateAccountUser(AccountUserCreateDto accountUserCreateDto)
        {
            var accountUserModel = _mapper.Map<AccountUser>(accountUserCreateDto);
            _accountUserRepo.CreateUser(accountUserModel);
            _accountUserRepo.SaveChanges();

            var accountUserReadDto = _mapper.Map<AlarmReadDto>(accountUserModel);
            return CreatedAtAction(nameof(GetUserById), new { id = accountUserReadDto.Id }, accountUserReadDto);
        }
        [HttpGet("all/{role}")]
        public ActionResult<IEnumerable<AccountUserReadDto>> GetAllAccountUsers(string role)
        {
            var accountUsers = _accountUserRepo.GetAllUsers(role);
            var model = _mapper.Map<IEnumerable<AccountUserReadDto>>(accountUsers);
            return Ok(model);
        }
        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<AccountUserReadDto> GetUserById(Guid id)
        {
            var accountUser = _accountUserRepo.GetUserById(id);
            if (accountUser != null)
            {
                return Ok(_mapper.Map<AccountUserReadDto>(accountUser));
            }
            return NotFound();
        }
        [HttpGet("users/{phoneIMEI}", Name = "GetUserByIMEI")]
        public ActionResult<AccountUserReadDto> GetUserByIMEI(string phoneIMEI)
        {
            var accountUser = _accountUserRepo.GetUserByIMEI(phoneIMEI);
            if (accountUser != null)
            {
                return Ok(_mapper.Map<AccountUserReadDto>(accountUser));
            }
            return NotFound();
        }
        [HttpGet("users/{phoneIMEI}/{authPrivateKey}", Name = "GetUserByIMEIAndPrivateKey")]

        public ActionResult<AccountUserReadDto> GetUserByIMEIAndPrivateKey(string phoneIMEI, string authPrivateKey)
        {
            var accountUser = _accountUserRepo.GetUserByIMEIAndPrivateKey(phoneIMEI, authPrivateKey);
            if (accountUser != null)
            {
                return Ok(_mapper.Map<AccountUserReadDto>(accountUser));
            }
            return NotFound();
        }
        // [HttpGet("checkauth")]
        /*   public ActionResult<AccountUserReadDto> CheckAuthorization(string phoneIMEI, string registrationPrivateKey, string role, IEnumerable<string> devices, string authPrivateKey)
           {
               var user = _accountUserRepo.CheckAuthorization(phoneIMEI, registrationPrivateKey, role, devices, authPrivateKey);
               if (user != null)
               {
                   return Ok(_mapper.Map<AccountUserReadDto>(user));
               }
               return NotFound();
           }*/
        // [HttpPost("register")]
        /*  public IActionResult Register(string phoneIMEI, string registrationCodeSMS)
          {
              _accountUserRepo.Register(phoneIMEI, registrationCodeSMS);
              return Ok();
          }*/
        // [HttpPost("controlDevice")]
        /*  public IActionResult OpenDoor(string phoneIMEI, string authPrivateKey, string deviceId, string command)
          {
              _accountUserRepo.OpenDoor(phoneIMEI, authPrivateKey, deviceId, command);
              return Ok();
          }*/
        // [HttpPost("messageStatus")]
        /*public IActionResult MessageStatus(string phoneIMEI, string authPrivateKey, string messageId, string status)
        {
            _accountUserRepo.MessageStatus(phoneIMEI, authPrivateKey, messageId, status);
            return Ok();
        }*/


    }

}
