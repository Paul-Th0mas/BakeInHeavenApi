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
        {   //Admin model mapping
            CreateMap<Admins, AdminReadDtos>();
            CreateMap<AdminCreatDtos, Admins>();
            CreateMap<Admins, AdminCreatDtos>();
            //Delicacy model mapping
            CreateMap<delicacys, DelicacyReadDtos>();
            CreateMap<DelicacyWriteDtos, delicacys>();
            CreateMap<delicacys, DelicacyWriteDtos>();
            //Delicacy_schedule mapping
            CreateMap<delicacy_Schedules, Delicacy_ScheduleReadDtos>();
            CreateMap<Delicacy_ScheduleWriteDtos, delicacy_Schedules>();
            CreateMap<delicacy_Schedules, Delicacy_ScheduleWriteDtos>();
            //orders mapping
            CreateMap<Orders, OrderReadDtos>();
            CreateMap<OrderCreateDtos, Orders>();
            CreateMap<Orders, OrderCreateDtos>();
        }
    }
}
