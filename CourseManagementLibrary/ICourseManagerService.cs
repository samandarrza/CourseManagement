using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagementLibrary
{
    public interface ICourseManagerService
    {
        List<Group> Groups { get; }
        public void AddGroup(Group group);
        public string EditGroup(string no);
        public void AddStudent(Student student);
        public void GetStudentsByGroupNo(string groupNo);
        public void GetAllStudents(Student student);
        public string FindGroupByNo(string groupNo);
        public void RemoveGroupByNo(string groupNo);
        public void Search(string value);
    }
}
