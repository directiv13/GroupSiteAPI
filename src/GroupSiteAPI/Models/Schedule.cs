    using System;
    using System.ComponentModel.DataAnnotations;
    
    namespace GroupSiteAPI.Models
    {
        public class Schedule
        {
            [Required]
            public int Id { get; set; }
            public int DayNumb { get; set; }
            public int WeekNumb { get; set; }
            [Required]
            public int SubjectId { get; set; }
            public  TimeSpan StartTime { get; set; }
        }
    }