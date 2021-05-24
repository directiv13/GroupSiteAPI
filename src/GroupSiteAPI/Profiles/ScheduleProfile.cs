using AutoMapper;
using GroupSiteAPI.Dtos;
using GroupSiteAPI.Models;

namespace GroupSiteAPI.Profiles
{
    public class ScheduleProfile: Profile
    {
        public ScheduleProfile()
        {
            CreateMap<Schedule, ScheduleDto>().ForMember(x => x.Subject, opt => opt.Ignore());
            CreateMap<Subject, SubjectDto>();
        }
    }
}