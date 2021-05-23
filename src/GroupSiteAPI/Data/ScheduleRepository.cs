using System.Collections.Generic;
using System.Linq;
using GroupSiteAPI.Models;

namespace GroupSiteAPI.Data
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly ScheduleContext _context;
        public ScheduleRepository(ScheduleContext context)
        {
            _context = context;
        }
        public void ChangeChocies(int choiceNumb, string newChoice)
        {
            throw new System.NotImplementedException();
        }
    
        public IEnumerable<Schedule> GetScheduleItemsByDayWeek(int day, int week)
        {
            return _context.ScheduleItems.Where(si => si.DayNumb == day && si.WeekNumb == week);
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return _context.Subjects;
        }

        public void MakeChoices(string[] chocies)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}