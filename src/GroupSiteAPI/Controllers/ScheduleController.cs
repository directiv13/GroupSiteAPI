using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GroupSiteAPI.Data;
using AutoMapper;
using GroupSiteAPI.Dtos;
using GroupSiteAPI.Models;

namespace GroupSiteAPI.Controllers{

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

        [HttpGet]
        public ActionResult<IEnumerable<SubjectDto>> GetSubjects()
        {
            var subjectItems = _repo.GetSubjects();
            return Ok(_mapper.Map<IEnumerable<SubjectDto>>(subjectItems));
        }

        [HttpGet("{day}/{week}")]
        public ActionResult<IEnumerable<Schedule>> GetSchedule(int day, int week)
        {
            return Ok(_repo.GetScheduleItemsByDayWeek(day, week));
        }
    }
}