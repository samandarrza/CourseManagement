using CourseManagementLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagementLibrary
{
    public class Student
    {
        public string Name;
        public string Surname;
        public string GroupNo;
        public WarrantyType Warranty;

        public void ShowStd()
        {
            Console.WriteLine($"{Name} {Surname} - {GroupNo} ({Warranty})");
        }
    }
}
