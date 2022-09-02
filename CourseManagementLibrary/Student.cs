using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagementLibrary
{
    public class Student
    {
        public string Name;     //Telebenin adi
        public string Surname;  //Telebenin soy adi
        public string GroupNo;  //Telebenin qrup nomresi
        public string Type;     //Telebenin novu

        public void Show()
        {
            Console.WriteLine($"{Name} {Surname} - {GroupNo} ({Type})");
        }
    }
}
