using GroupSiteAPI.Models;
using System.Collections.Generic;

namespace GroupSiteAPI.Data
{
    public interface IScheduleRepository
    {
        bool SaveChanges();
        void MakeChoices(int id, string[] chocies);
        void ChangeChocies(int choiceNumb, string newChoice);
        IEnumerable<Schedule> GetObviousSchedules();
        IEnumerable<Schedule> GetObviousSchedulesByWeek(int weekNumb);
        IEnumerable<Schedule> GetElectiveSchedules(int id);
        IEnumerable<Schedule> GetElectiveSchedulesByWeek(int id, int weekNumb);
        IEnumerable<Subject> GetObviousSubjects();
        IEnumerable<Subject> GetElectiveSubjects(int id);
        Subject GetSubjectById(int id);
    }
}