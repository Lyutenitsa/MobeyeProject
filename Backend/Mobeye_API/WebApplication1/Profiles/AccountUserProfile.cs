using AutoMapper;
using Mobeye_API.Dtos;
using Mobeye_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobeye_API.Profiles
{
    public class AccountUserProfile : Profile
    {
        public AccountUserProfile()
        {
            //source -> target
            CreateMap<AccountUser, AccountUserReadDto>();
            CreateMap<AccountUserReadDto, AccountUser>();
        }
    }
}
