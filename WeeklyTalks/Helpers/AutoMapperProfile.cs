using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeeklyTalks.Dtos;
using WeeklyTalks.Models;

namespace WeeklyTalks.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Users, UserDto>();
            CreateMap<UserDto, Users>();

            CreateMap<Users, UpdateUserDto>();
            CreateMap<UpdateUserDto, Users>();

            CreateMap<Meetings, CreateMeetingDto>();
            CreateMap<CreateMeetingDto, Meetings>();

            CreateMap<Employees, CreateEmployeeDto>();
            CreateMap<CreateEmployeeDto, Employees>();
        }
    }
}
