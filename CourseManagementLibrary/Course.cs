using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagementLibrary
{
    public class Course : ICourseManagerService
    {
        public List<Group> Groups { get; set; }

        public void AddGroup(Group group)
        {
            Groups.Add(group);
        }

        public void AddStudent(Student student)
        {
           List<Student> Students = new List<Student>();
           Students.Add(student);
        }

        public void EditGroup(string groupNo)
        {
            
        }

        public void FindGroupByNo(string groupNo)
        {
            
        }

        public void GetAllStudents(Student student)
        {
            
        }

        public void GetStudentsByGroupNo(string groupNo)
        {
            
        }

        public void RemoveGroupByNo(string groupNo)
        {
            
        }

        public void Search(string value)
        {
            
        }
    }
}
