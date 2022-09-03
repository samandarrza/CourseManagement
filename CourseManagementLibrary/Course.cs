using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace CourseManagementLibrary
{
    public class Course : ICourseManagerService
    {

        private List<Group> _groups = new List<Group>();
        public List<Group> Groups { get => _groups; }
        
        public void AddGroup(Group group)
        {
            if (!CheckGroupNo(group.No))
            {
                _groups.Add(group);
            }           
        }

        public bool CheckGroupNo(string no)
        {
            foreach (var item in Groups)
            {
                if (item.No == no)
                    return true;
            }
            return false;
        }

        public void AddStudent(Student student)
        {
            FindGroupByNo(student.GroupNo).AddStudent(student);
        }

        public void EditGroup(string oldNo, string newNo)
        {
            for (int i = 0; i < Groups.Count; i++)
            {
                if (oldNo == Groups[i].No)
                {
                    Groups[i].No = newNo;
                }
            }
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
