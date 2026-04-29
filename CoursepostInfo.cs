using System;

namespace Learning_Management_and_Academic_Monitoring_system
{
    public class CoursePostInfo
    {
        public int PostID { get; set; }
        public int CourseID { get; set; }
        public int InstructorID { get; set; }
        public string InstructorName { get; set; }
        public string PostType { get; set; }   // "Announcement" | "Activity" | "Link"
        public string Title { get; set; }
        public string Content { get; set; }
        public string LinkURL { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime PostedDate { get; set; }

        public bool IsActivity => PostType == "Activity";
        public bool IsLink => PostType == "Link";
        public bool IsAnnouncement => PostType == "Announcement";

        public string DueDateDisplay =>
            DueDate.HasValue ? DueDate.Value.ToString("MMM dd, yyyy  hh:mm tt") : "";

        public string PostedDateDisplay =>
            PostedDate.ToString("MMM dd, yyyy  hh:mm tt");
    }
}
