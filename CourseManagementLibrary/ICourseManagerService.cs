using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagementLibrary
{
    public interface ICourseManagerService
    {
        List<Group> Groups { get; }
        public void AddGroup(Group group);
        public void EditGroup1(string oldNo, string newNo);
        public void AddStudent(Student student);
        public void GetStudentsByGroupNo(string groupNo);
        public void GetAllStudents();
        public Group FindGroupByNo(string no);
        public void RemoveGroupByNo(string groupNo);
        public void Search(string value);
    }
}
