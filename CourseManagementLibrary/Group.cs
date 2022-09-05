using CourseManagementLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagementLibrary
{
    public class Group
    {
        public string No;
        public CategoryType Category;
        private byte _limit;
        private OnlineType _isOnline;
        public OnlineType IsOnline
        {
            get
            {
                return _isOnline;
            }
            set
            {
                if (value == OnlineType.Online)
                    _limit = 15;
                else if (value == OnlineType.Offline)
                    _limit = 10;
            }
        }
        public byte Limit { get => _limit; }
        public List<Student> Students = new List<Student>(0);
        public void AddStudent(Student student)
        {
            if (Students.Count <= Limit || student.GroupNo == No)
            {
                Students.Add(student);
            }
        }
        public void Show()
        {
            Console.WriteLine($"{No} - {Category} ({IsOnline}) - bos yer:({Limit - Students.Count})");
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
                string[] category = Enum.GetNames(typeof(CategoryType));
                string[] online = Enum.GetNames(typeof(OnlineType));
                string[] warranty = Enum.GetNames(typeof(WarrantyType));

                if (fullName.ToLower().Contains(value) || Students[i].GroupNo.ToLower().Contains(value)
                    || category[i].ToLower().Contains(value)|| online[i].ToLower().Contains(value) || warranty[i].ToLower().Contains(value))
                {
                    Students[i].ShowStd();
                }
            }
        }
    }
}
