﻿using AutoMapper;
using Mobeye_API.Dtos;
using Mobeye_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobeye_API.Profiles
{
    public class AlarmsProfile : Profile
    {
        public AlarmsProfile()
        {
            //source -> target
            CreateMap<Alarm, AlarmReadDto>();
            CreateMap<AlarmCreateDto, Alarm>();
            CreateMap<AlarmUpdateDto, Alarm>();
            CreateMap<Alarm, AlarmUpdateDto>();
        }
    }
}
