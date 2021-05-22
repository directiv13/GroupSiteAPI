using GroupSiteAPI.Models;

namespace GroupSiteAPI.Data
{
    public interface IScheduleRepository
    {
        bool SaveChanges();
        void MakeChoices(string[] chocies);
        void ChangeChocies(int choiceNumb, string newChoice);
        
    }
}