using GroupSiteAPI.Models;
using System.Collections.Generic;

namespace GroupSiteAPI.Data
{
    public interface IScheduleRepository
    {
        bool SaveChanges();
        void MakeChoices(string[] chocies);
        void ChangeChocies(int choiceNumb, string newChoice);
        IEnumerable<Schedule> GetObviousSchedules();
        IEnumerable<Schedule> GetObviousSchedulesByWeek(int weekNumb);
        IEnumerable<Schedule> GetElectiveSchedules(string email);
        IEnumerable<Schedule> GetElectiveSchedulesByWeek(string email, int weekNumb);
        IEnumerable<Subject> GetObviousSubjects();
        IEnumerable<Subject> GetElectiveSubjects(string email);
        Subject GetSubjectById(int id);
    }
}