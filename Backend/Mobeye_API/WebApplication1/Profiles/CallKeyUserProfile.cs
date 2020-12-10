using AutoMapper;
using Mobeye_API.Dtos;
using Mobeye_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobeye_API.Profiles
{
    public class CallKeyUserProfile : Profile
    {
        public CallKeyUserProfile()
        {
            //source -> target
            CreateMap<CallKeyUser, CallKeyUserReadDto>();
            CreateMap<CallKeyUserReadDto, CallKeyUser>();
        }
    }
}
