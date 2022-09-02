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
            if (group.Limit > Groups.Count)
            {
                Groups.Add(group);
            } 
        }

        public static bool CheckGroupNo(string no)
        {
            Group group = new Group();
            if (no != group.No)
            {
                return true;
            }
            return false;
        }

        public void AddStudent(Student student)
        {
            AddStudent(student);
        }

        public string EditGroup(string no)
        {
            Group group = new Group();

            if (no != group.No)
            {
                group.No = no;
            }
            return group.No;
        }

        public string FindGroupByNo(string no)
        {
            Group group = new Group();
            if (no == group.No)
            {
                return group.No;
            }
            return "sehv";
        }

        public void GetAllStudents(Student student)
        {

            //yeniden bax
            student.Show();
        }

        public void GetStudentsByGroupNo(string no)
        {
            Group group = new Group();
            Student student = new Student();
            if (no == group.No)
            {
               student.Show();
            }
        }

        public void RemoveGroupByNo(string no)
        {
            Group group = new Group();
            if (no == group.No)
            {
                Groups.Remove(group);
            }
        }

        public void Search(string value)
        {
            value = value.ToLower();
            Student student = new Student();

                string fullName = student.Name + " " + student.Surname;

            if (fullName.ToLower().Contains(value))
            {
                student.Show();
            }
        }
    }
}
