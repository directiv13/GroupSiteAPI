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
        public void MakeChoices(int id, string[] choices)
        {
            var userChoices = GetChoices(id);

            if(userChoices.Count() > 0)
            {
                foreach (var choice in userChoices)
                    DeleteChoice(choice);
            }

            List<Subject> subjects = new List<Subject>();
            foreach (string choice in choices)
            {
                var subject = _context.Subjects.FirstOrDefault(s => s.Name == choice && s.IsElective);
                if(subject != null)
                    subjects.Add(subject);
                else
                {
                    throw new System.ArgumentException("There is no elective subject as " + choice);
                }
            }

            foreach (var subject in subjects)
            {
                _context.UserChoices.Add(new UserChoice()
                {
                    UserId = id,
                    SubjectId = subject.Id
                });
            }
        }

        public IEnumerable<UserChoice> GetChoices(int id)
        {
            return _context.UserChoices.Where(us => us.UserId == id).ToList();
        }

        public void DeleteChoice(UserChoice choice)
        {
            if (choice == null)
                throw new System.ArgumentNullException(nameof(choice));
            _context.UserChoices.Remove(choice);
        }
        public IEnumerable<Schedule> GetObviousSchedules()
        {
            return _context.ScheduleItems.Where(si => !si.Subject.IsElective).ToList();
        }
        public IEnumerable<Schedule> GetObviousSchedulesByWeek(int weekNumb)
        {
            return _context.ScheduleItems.Where(si => !si.Subject.IsElective && si.WeekNumb == weekNumb).ToList();
        }

        public IEnumerable<Schedule> GetElectiveSchedules(int id)
        {
            var userChoices = _context.UserChoices.Where(uc => uc.UserId == id).ToList();

            List<Schedule> electiveSchedule = new List<Schedule>();
            foreach(var choice in userChoices)
            {
                electiveSchedule.AddRange(_context.ScheduleItems.Where(si => si.SubjectId == choice.SubjectId).ToList());
            }

            return electiveSchedule;
        }
        public IEnumerable<Schedule> GetElectiveSchedulesByWeek(int id, int weekNumb)
        {
            var userChoices = _context.UserChoices.Where(uc => uc.UserId == id).ToList();

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
        public IEnumerable<Subject> GetElectiveSubjects(int id)
        {
            var userChoices = _context.UserChoices.Where(uc => uc.UserId == id).ToList();

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
        public User GetUser(int id)
        {
            var user = _context.Users.Where(user => user.Id == id).FirstOrDefault();
            
            return user;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}