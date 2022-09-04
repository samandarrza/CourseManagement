using CourseManagementLibrary;
using CourseManagementLibrary.Enums;
using System;
using System.Reflection.Metadata;

namespace CourseManagementApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Course course = new Course();
            string opt;
            
            do
            {
                ShowMenu();
                Console.Write("Secim edin: ");
                opt = Console.ReadLine();
                Console.Clear();

                switch (opt)
                {
                    case "1.1":
                        ShowGroup(course);
                        break;
                    case "1.2":
                        AddGroup(course);
                        break;
                    case "1.3":
                        EditGroup(course);
                        break;
                    case "2.1":
                        StudentsByGroupNo(course);
                        break;
                    case "2.2":
                        Console.WriteLine("Butun telebelerin siyahisi");
                        course.GetAllStudents();
                        break;
                    case "2.3":
                        AddStudent(course);
                        break;
                    case "2.4":
                        Search(course);
                        break;
                    case "2.5":
                        DeleteGroup(course);
                        break;
                    case "0":
                        Console.WriteLine("Programdan cixdi!");
                        break;
                    default:
                        Console.WriteLine("Yanlis secim etdiniz!");
                        break;
                }

            } while (opt != "0");

        }
        static void ShowMenu()
        {
            Console.WriteLine("=====Course Management App=====");
            Console.WriteLine(" 1.1 - Qruplarin siyahisini goster");
            Console.WriteLine(" 1.2 - Yeni qrup yarat ");
            Console.WriteLine(" 1.3 - Qrup uzerinde duzelis et");
            Console.WriteLine(" 2.1 - Qrupdaki telebelerin siyahisini goster");
            Console.WriteLine(" 2.2 - Butun telebelerin siyahisini goster");
            Console.WriteLine(" 2.3 - Telebe elave et ");
            Console.WriteLine(" 2.4 - Umumi axtaris");
            Console.WriteLine(" 2.5 - Group sil");
            Console.WriteLine(" 0 - Menudan cix");
            Console.WriteLine("===============================");
        }
        static void ShowGroup(Course course)
        {
            Console.WriteLine("Qruplarin siyahisi");
            for (int i = 0; i < course.Groups.Count; i++)
            {
                course.Groups[i].Show();
            }
        }
        static void AddGroup(Course course)
        {
            Console.WriteLine("Yeni qrup yarat");
            Console.Write("Qrup nomresi: ");
            string no;
            bool hasNo = false;
            bool checkNo = true;
            do
            {
                if (hasNo == true)
                    Console.WriteLine("Bu adda qrup var!");
                if (checkNo == false)
                    Console.WriteLine("1 boyuk herf ve 3 reqemden ibaret qrup adi daxil edin!");
                no = Console.ReadLine();
                hasNo = course.HasGroupNo(no);
                checkNo = Course.CheckGroupNo(no);
            } while (hasNo || !checkNo);
            string category;
            do
            {
                Console.WriteLine("Asagidaki kateqoriyalardan birini secin: ");
                foreach (var item in Enum.GetNames(typeof(CategoryType)))
                {
                    Console.WriteLine(item);
                }
                category = Console.ReadLine();

            } while (!Enum.IsDefined(typeof(CategoryType), category));
            CategoryType categoryType = Enum.Parse<CategoryType>(category);

            Console.Write("Qrup veziyyeti: ");
            string isOnline;
            do
            {
                Console.WriteLine("Asagidaki kateqoriyalardan birini secin: ");
                foreach (var item in Enum.GetNames(typeof(OnlineType)))
                {
                    Console.WriteLine(item);
                }
                isOnline = Console.ReadLine();

            } while (!Enum.IsDefined(typeof(OnlineType), isOnline));
            OnlineType onlineType = Enum.Parse<OnlineType>(isOnline);
            Group group = new Group();
            group.No = no;
            group.Category = categoryType;
            group.IsOnline = onlineType;
            course.AddGroup(group);
        }
        static void EditGroup(Course course)
        {
            string opt2;
            do
            {
                Console.WriteLine("=====Course Management App=====");
                Console.WriteLine("1. Qrup adini tam deyis");
                Console.WriteLine("2. Qrup adinin reqemlerini deyis");
                Console.WriteLine("0. Geri don");
                Console.WriteLine("===============================");
                Console.WriteLine("Secim edin");
                opt2 = Console.ReadLine();
                switch (opt2)
                {
                    case "1":
                        EditGrp1(course);
                        break;
                    case "2":
                        EditGrp2(course);
                        break;
                    case "0":
                        Console.WriteLine("Geri dön");
                        break;
                    default:
                        break;
                }
            } while (opt2 != "0");
        }
        static void EditGrp1(Course course)
        {
            Console.WriteLine("Qrup uzerinde duzelis et");
            Console.Write("Kohne qrup nomresi daxil edin: ");
            string oldNo;
            bool hasOldNo = true;
            bool checkOldNo = true;
            do
            {
                if (checkOldNo == false)
                {
                    Console.WriteLine("1 boyuk herf ve 3 reqemden ibaret qrup adi daxil edin!");
                }
                else if (hasOldNo == false)
                {
                    Console.WriteLine("Bu adda qrup yoxdur!");
                    return;
                }
                oldNo = Console.ReadLine();
                hasOldNo = course.HasGroupNo(oldNo);
                checkOldNo = Course.CheckGroupNo(oldNo);
            } while (!hasOldNo || !checkOldNo);
            Console.Write("Yeni qrup nomresi daxil edin: ");
            string newNo;
            bool hasNewNo = false;
            bool checkNewNo = true;
            do
            {
                if (checkNewNo == false)
                {
                    Console.WriteLine("1 boyuk herf ve 3 reqemden ibaret qrup adi daxil edin!");
                }
                else if (hasNewNo == true)
                {
                    Console.WriteLine("Bu adda qrup var!");
                    return;
                }
                newNo = Console.ReadLine();
                hasNewNo = course.HasGroupNo(newNo);
                checkNewNo = Course.CheckGroupNo(newNo);
            } while (hasNewNo || !checkNewNo);
            course.EditGroup(oldNo, newNo);
        }
        static void EditGrp2(Course course)
        {
            Console.WriteLine("Qrup uzerinde duzelis et");
            Console.Write("Kohne qrup nomresi daxil edin: ");
            string oldNo;
            bool hasOldNo = true;
            bool checkOldNo = true;
            do
            {
                if (checkOldNo == false)
                {
                    Console.WriteLine("1 boyuk herf ve 3 reqemden ibaret qrup adi daxil edin!");
                }
                else if (hasOldNo == false)
                {
                    Console.WriteLine("Bu adda qrup yoxdur!");
                    return;
                }
                oldNo = Console.ReadLine();
                hasOldNo = course.HasGroupNo(oldNo);
                checkOldNo = Course.CheckGroupNo(oldNo);
            } while (!hasOldNo || !checkOldNo);
            Console.Write("Yeni qrup nomresinin reqemlerini daxil edin: ");
            string newNo;
            bool hasNewNo = false;
            bool checkNewNo = true;
            do
            {
                if (checkNewNo == false)
                {
                    Console.WriteLine("3 reqemli eded daxil edin!");
                }
                else if (hasNewNo == true)
                {
                    Console.WriteLine("Bu adda qrup var!");
                    return;
                }
                newNo = Console.ReadLine();
                hasNewNo = course.HasGroupNo(newNo);
                checkNewNo = Course.CheckGroupNo2(newNo);
            } while (hasNewNo || !checkNewNo);
            course.EditGroup2(oldNo, newNo);
        }
        static void StudentsByGroupNo(Course course)
        {
            Console.WriteLine("Qrupdaki telebelerin siyahisi");
            Console.Write("Qrup nomresi: ");
            string wantedNo;
            bool hasNo = true;
            bool checkNo = true;
            do
            {
                if (checkNo == false)
                {
                    Console.WriteLine("1 boyuk herf ve 3 reqemden ibaret qrup adi daxil edin!");
                }
                else if (hasNo == false)
                {
                    Console.WriteLine("Bu adda qrup yoxdur!");
                    return;
                }
                wantedNo = Console.ReadLine();
                hasNo = course.HasGroupNo(wantedNo);
                checkNo = Course.CheckGroupNo(wantedNo);
            } while (!hasNo || !checkNo);
            course.GetStudentsByGroupNo(wantedNo);
        }
        static void AddStudent(Course course)
        {
            Console.WriteLine("Telebe elave et");
            Console.Write("Qrup nomresi: ");
            string no;
            bool hasNo = true;
            bool checkNo = true;
            do
            {
                if (checkNo == false)
                {
                    Console.WriteLine("1 boyuk herf ve 3 reqemden ibaret qrup adi daxil edin!");
                }
                else if (hasNo == false)
                {
                    Console.WriteLine("Bu adda qrup yoxdur!");
                    return;
                }
                no = Console.ReadLine();
                hasNo = course.HasGroupNo(no);
                checkNo = Course.CheckGroupNo(no);
            } while (!hasNo || !checkNo);

            Group StudentGroup = course.FindGroupByNo(no);
            if (StudentGroup.Students.Count == StudentGroup.CheckLimit())
            {
                Console.WriteLine("Qrup doludur!");
                return;
            }

            string name;
            do
            {
                Console.Write("Ad: ");
                name = Console.ReadLine();
            } while (!name.IsContainsLetter());
            string surmane;
            do
            {
                Console.Write("Soyad: ");
                surmane = Console.ReadLine();
            } while (!surmane.IsContainsLetter());

            

            Console.Write("Qrup tipi: ");
            string warranty;
            do
            {
                Console.WriteLine("Asagidaki kateqoriyalardan birini secin: ");
                foreach (var item in Enum.GetNames(typeof(WarrantyType)))
                {
                    Console.WriteLine(item);
                }
                warranty = Console.ReadLine();

            } while (!Enum.IsDefined(typeof(WarrantyType), warranty));
            WarrantyType warrantyType = Enum.Parse<WarrantyType>(warranty);

            Student student = new Student()
            {
                Name = name.ToCapitalize(),
                Surname = surmane.ToCapitalize(),
                GroupNo = no,
                Warranty = warrantyType
            };
            course.AddStudent(student);
        }
        static void Search(Course course)
        {
            Console.WriteLine("Umumi axtaris");
            Console.Write("Axtardiginiz sozu daxil edin: ");
            string wantedValue = Console.ReadLine();
            course.Search(wantedValue);
        }
        static void DeleteGroup(Course course)
        {
            Console.WriteLine("Qrup sil");
            Console.Write("Qrup nomresi daxil edin: ");
            string delNo;
            bool hasNo = true;
            bool checkNo = true;
            do
            {
                if (checkNo == false)
                {
                    Console.WriteLine("1 boyuk herf ve 3 reqemden ibaret qrup adi daxil edin!");
                }
                else if (hasNo == false)
                {
                    Console.WriteLine("Bu adda qrup yoxdur!");
                    return;
                }
                delNo = Console.ReadLine();
                hasNo = course.HasGroupNo(delNo);
                checkNo = Course.CheckGroupNo(delNo);
            } while (!hasNo || !checkNo);
            course.RemoveGroupByNo(delNo);
        }
    }
}
