using CourseManagementLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CourseManagementLibrary
{
    public class Group
    {
        public string No;
        public CategoryType Category;
        public OnlineType IsOnline;
        private byte _limit;

        List<Student> Students = new List<Student>(0);

        public void AddStudent(Student student)
        {
            if (Students.Count <= CheckLimit() || student.GroupNo == No)
                Students.Add(student);       
        }

        public byte CheckLimit()
        {
            if (IsOnline == OnlineType.Online)
                return _limit = 15;
            else
                return _limit = 10;
        }

        public void Show()
        {
            Console.WriteLine($"{No} - {Category} ({IsOnline})");
        }

        public void ShowAllStudent()
        {
            for (int i = 0; i < Students.Count; i++)
            {
                Students[i].ShowStd();
            }
        }

        public void ShowStudentByGroup(string groupno)
        {
            for (int i = 0; i < Students.Count; i++)
            {
                if (groupno == Students[i].GroupNo)
                {
                    Students[i].ShowStd();
                }
            }
        }

        public void Search(string value)
        {
            value = value.ToLower();

            for (int i = 0; i < Students.Count; i++)
            {
                string fullName = Students[i].Name +" "+ Students[i].Surname;

                if (fullName.ToLower().Contains(value) 
                    ||Students[i].GroupNo.ToLower().Contains(value) 
                    ||Students[i].Type.ToLower().Contains(value))
                {
                    Students[i].ShowStd();
                }
            }
        }

    }
}
