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
        public void MakeChoices(string[] chocies)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Schedule> GetObviousSchedules()
        {
            return _context.ScheduleItems.Where(si => !si.Subject.IsElective).ToList();
        }
        public IEnumerable<Schedule> GetObviousSchedulesByWeek(int weekNumb)
        {
            return _context.ScheduleItems.Where(si => !si.Subject.IsElective && si.WeekNumb == weekNumb).ToList();
        }

        public IEnumerable<Schedule> GetElectiveSchedules(string email)
        {
            var user = GetUser(email);
            var userChoices = _context.UserChoices.Where(uc => uc.UserId == user.Id).ToList();

            List<Schedule> electiveSchedule = new List<Schedule>();
            foreach(var choice in userChoices)
            {
                electiveSchedule.AddRange(_context.ScheduleItems.Where(si => si.SubjectId == choice.SubjectId).ToList());
            }

            return electiveSchedule;
        }
        public IEnumerable<Schedule> GetElectiveSchedulesByWeek(string email, int weekNumb)
        {
            var user = GetUser(email);
            var userChoices = _context.UserChoices.Where(uc => uc.UserId == user.Id).ToList();

            List<Schedule> electiveSchedule = new List<Schedule>();
            foreach(var choice in userChoices)
            {
                electiveSchedule.AddRange(_context.ScheduleItems.Where(si => si.SubjectId == choice.SubjectId && si.WeekNumb == weekNumb).ToList());
            }

            return electiveSchedule;
        }

        public IEnumerable<Subject> GetObviousSubjects()
        {
            return _context.Subjects.Where(s => !s.IsElective);
        }
        public IEnumerable<Subject> GetElectiveSubjects(string email)
        {
            User user = GetUser(email);

            var userChoices = _context.UserChoices.Where(uc => uc.UserId == user.Id).ToList();

            List<Subject> electiveSubjects = new List<Subject>();
            foreach(var choice in userChoices)
            {
                electiveSubjects.Add(_context.Subjects.Single(s => s.Id == choice.SubjectId));
            }

            return electiveSubjects;
        }
        public Subject GetSubjectById(int id)
        {
            return _context.Subjects.Single(s => s.Id == id);
        }
        public User GetUser(string email)
        {
            var user = _context.Users.Where(user => user.Email == email).FirstOrDefault();
            user.Password = null;

            return user;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}