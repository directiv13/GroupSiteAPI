using System;

namespace GroupSiteAPI.Dtos
{
    public class ScheduleDto
    {
        public int DayNumb { get; set; }
        public int WeekNumb { get; set; }
        public SubjectDto Subject { get; set; }
        public TimeSpan StartTime { get; set; }
    }
}