using System.Collections.Generic;

namespace GroupSiteAPI.Dtos
{
    public class ScheduleDto
    {
        public IEnumerable<ClassItem>[] Schedule { get; set; }
    }
}