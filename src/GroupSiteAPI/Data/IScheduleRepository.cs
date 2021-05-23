using GroupSiteAPI.Models;
using System.Collections.Generic;

namespace GroupSiteAPI.Data
{
    public interface IScheduleRepository
    {
        bool SaveChanges();
        void MakeChoices(string[] chocies);
        void ChangeChocies(int choiceNumb, string newChoice);
        IEnumerable<Subject> GetSubjects();
        IEnumerable<Schedule> GetScheduleItemsByDayWeek(int day, int week);
    }
}