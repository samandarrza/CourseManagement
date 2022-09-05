using CourseManagementLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagementLibrary
{
    public class Course : ICourseManagerService
    {

        private List<Group> _groups = new List<Group>();
        public List<Group> Groups { get => _groups; }
        
        public void AddGroup(Group group)
        {
            if (!HasGroupNo(group.No) && CheckGroupNo(group.No))
            {
                _groups.Add(group);
            }           
        }
        public bool HasGroupNo(string no)
        {
            foreach (var item in Groups)
            {
                if (item.No == no)
                    return true;
            }
            return false;
        }
        public static bool CheckGroupNo(string groupNo)
        {
            if (String.IsNullOrEmpty(groupNo) || !char.IsLetter(groupNo[0]) || !char.IsUpper(groupNo[0]) || groupNo.Length != 4)
                return false;

            for (int i = 1; i < groupNo.Length; i++)
            {
                if (!Char.IsDigit(groupNo[i]))
                    return false;
            }
            return true;
        }
        public void AddStudent(Student student)
        {

            FindGroupByNo(student.GroupNo).AddStudent(student);
        }
        public static bool CheckGroupNo2(string groupNo)
        {
            if (String.IsNullOrEmpty(groupNo) || groupNo.Length != 3)
                return false;

            for (int i = 0; i < groupNo.Length; i++)
            {
                if (!Char.IsDigit(groupNo[i]))
                    return false;
            }
            return true;
        }
        public void EditGroup2(string oldNo, string newNo)
        {
            for (int i = 0; i < Groups.Count; i++)
            {
                if (_groups[i].No.Substring(1) == newNo)
                {
                    Console.WriteLine("Bu qrup nomresi var!");
                    return;
                }   
            }
            for (int i = 0; i < Groups.Count; i++)
                if (HasGroupNo(oldNo) && CheckGroupNo2(newNo))
                    _groups[i].No = oldNo[0] + newNo;
        }
        public void EditGroup1(string oldNo, string newNo)
        {
            for (int i = 0; i < Groups.Count; i++)
                if (HasGroupNo(oldNo) && !HasGroupNo(newNo) && CheckGroupNo(newNo))
                    _groups[i].No = newNo;
        }
        public Group FindGroupByNo(string no)
        {
            for (int i = 0; i < Groups.Count; i++)
            {
                if (no == Groups[i].No)
                    return Groups[i];
            }
            return null;
        }
        public void GetAllStudents()
        {
            for (int i = 0; i < Groups.Count; i++)
            {
                Groups[i].ShowAllStudent();
            }
            
        }
        public void GetStudentsByGroupNo(string groupno)
        {
            for (int i = 0; i < Groups.Count; i++)
            {
                if (groupno == Groups[i].No)
                {
                    Groups[i].ShowStudentByGroup(groupno);
                }   
            }
        }
        public void RemoveGroupByNo(string no)
        {
            for (int i = 0; i < Groups.Count; i++)
            {
                if (Groups[i].No == no)
                {
                    _groups.Remove(Groups[i]);
                }
            }
        }
        public void Search(string value)
        {
            for (int i = 0; i < Groups.Count; i++)
            {
                _groups[i].Search(value);
            }
        }
    }
}
