using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Management_and_Academic_Monitoring_system
{
    public class StudentSubjectInfo
    {
        public int CourseID { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }
        public string Schedule { get; set; }
        public string Room { get; set; }
        public string Semester { get; set; }
        public int ActivityCount { get; set; }

        // Bonus: Display name
        public string FullName => $"{CourseCode} - {CourseName}";
    }
}
