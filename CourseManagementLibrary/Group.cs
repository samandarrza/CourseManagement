using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagementLibrary
{
    public class Group
    {
        public string No;
        public string Category;
        public bool IsOnline;
        private byte _limit;

        public byte Limit {get { return _limit;}}

        List<Student> Students = new List<Student>(0);

        public void AddStudent(Student student)
        {
            if (Course.CheckGroupNo(No)|| _limit < CheckLimit())
            {
                Students.Add(student);
            } 
        }

        public byte CheckLimit()
        {
            if (IsOnline)
                return _limit = 15;
            else
                return _limit = 10;
        }

    }
}
