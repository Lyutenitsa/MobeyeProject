using AutoMapper;
using Mobeye_API.Dtos;
using Mobeye_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobeye_API.Profiles
{
    public class ContactUserProfile : Profile
    {
        public ContactUserProfile()
        {
            CreateMap<ContactUser, ContactUserReadDto>();
            CreateMap<ContactUserReadDto, ContactUser>();
        }
    }
}
