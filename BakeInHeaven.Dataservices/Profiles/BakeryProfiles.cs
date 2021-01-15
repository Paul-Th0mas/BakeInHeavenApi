using AutoMapper;
using Dataservices.Dtos;
using Dataservices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dataservices.Profiles
{
    class BakeryProfiles :Profile
    {
        public BakeryProfiles()
        {
            CreateMap<Admins, AdminReadDtos>();
            CreateMap<AdminCreatDtos, Admins>();
            CreateMap<Admins, AdminCreatDtos>();
            CreateMap<delicacys, DelicacyReadDtos>();
            CreateMap<DelicacyWriteDtos, delicacys>();
            CreateMap<delicacys, DelicacyWriteDtos>();
            CreateMap<delicacy_Schedules, Delicacy_ScheduleReadDtos>();
            CreateMap<Delicacy_ScheduleWriteDtos, delicacy_Schedules>();
            CreateMap<delicacy_Schedules, Delicacy_ScheduleWriteDtos>();
        }
    }
}
