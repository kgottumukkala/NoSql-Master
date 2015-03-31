
using System;
using System.Collections.Generic;

namespace NoSqlWeb.Models
{
    public class Course
    {
        //public Course(PostCourse postCourse)
        //{
        //    Title = postCourse.Title;
        //    Description = postCourse.Description;
        //    Duration = postCourse.Duration;
        //    StartDate = postCourse.StartDate;
        //    EndDate = postCourse.EndDate;
        //    CreatedDate = postCourse.CreatedDate;
        //    CreatedBy = postCourse.CreatedBy;
            
        //}

        

        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public List<AvFile> Videos = new List<AvFile>();
    }
}