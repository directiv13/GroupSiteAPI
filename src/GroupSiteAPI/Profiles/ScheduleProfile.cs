using AutoMapper;
using GroupSiteAPI.Dtos;
using GroupSiteAPI.Models;

namespace GroupSiteAPI.Profiles
{
    public class ScheduleProfile: Profile
    {
        public ScheduleProfile()
        {
            CreateMap<Subject, SubjectDto>();
        }
    }
}