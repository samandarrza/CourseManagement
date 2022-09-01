using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagementLibrary
{
    public class Group
    {
        public string No;
        public string Category;
        public string IsOnline;
        public byte Limit;
        List<Student> Students = new List<Student>(0);


    }
}
