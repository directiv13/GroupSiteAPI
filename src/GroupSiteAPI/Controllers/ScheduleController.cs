using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GroupSiteAPI.Data;
using AutoMapper;
using GroupSiteAPI.Dtos;

namespace GroupSiteAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleRepository _repo;
        private readonly IMapper _mapper;
        public ScheduleController(IScheduleRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("{weekNumb}")]
        public ActionResult<IEnumerable<IEnumerable<ScheduleDto>>> GetSchedule(int weekNumb)
        {
            string email = HttpContext.User.Identity.Name;

            var obviousSchedules = _repo.GetObviousSchedulesByWeek(weekNumb);
            var electiveSchedules = _repo.GetElectiveSchedulesByWeek(email, weekNumb);

            List<ScheduleDto>[] resultSchedule = new List<ScheduleDto>[7];
            foreach (var schedule in obviousSchedules)
            {
                ScheduleDto scheduleDto = _mapper.Map<ScheduleDto>(schedule);
                scheduleDto.Subject = _mapper.Map<SubjectDto>(_repo.GetSubjectById(schedule.SubjectId));
                if (resultSchedule[scheduleDto.DayNumb - 1] == null)
                    resultSchedule[scheduleDto.DayNumb - 1] = new List<ScheduleDto>();
                resultSchedule[scheduleDto.DayNumb - 1].Add(scheduleDto);
            }
            foreach (var schedule in electiveSchedules)
            {
                ScheduleDto scheduleDto = _mapper.Map<ScheduleDto>(schedule);
                scheduleDto.Subject = _mapper.Map<SubjectDto>(_repo.GetSubjectById(schedule.SubjectId));
                if (resultSchedule[scheduleDto.DayNumb - 1] == null)
                    resultSchedule[scheduleDto.DayNumb - 1] = new List<ScheduleDto>();
                resultSchedule[scheduleDto.DayNumb - 1].Add(scheduleDto);
            }
            for(int i = 0; i < resultSchedule.Length; i++)
            {
                resultSchedule[i] = resultSchedule[i] == null ? null : resultSchedule[i].OrderBy(x => x.StartTime.Hours).ToList();
            }

            return resultSchedule;
        }
    }
}