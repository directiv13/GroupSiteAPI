    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
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
            public Subject Subject { get; set; }
            [Column(TypeName="time")]
            public  TimeSpan StartTime { get; set; }
        }
    }