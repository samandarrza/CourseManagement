using CourseManagementLibrary;
using CourseManagementLibrary.Enums;
using System;

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
                        Console.WriteLine("Qruplarin siyahisi");
                        for (int i = 0; i < course.Groups.Count; i++)
                        {
                            course.Groups[i].Show();
                        }
                        break;
                    case "1.2":
                        AddGroup(course);
                        break;
                    case "1.3":
                        Console.WriteLine("Qrup uzerinde duzelis et");
                        Console.Write("Kohne qrup nomresi daxil edin: ");
                        string oldNo = Console.ReadLine();
                        Console.Write("Yeni qrup nomresi daxil edin: ");
                        string newNo = Console.ReadLine();
                        course.EditGroup(oldNo, newNo);
                        break;
                    case "2.1":
                        Console.WriteLine("Qrupdaki telebelerin siyahisi");
                        Console.Write("Qrup nomresi: ");
                        string wantedNo = Console.ReadLine();
                        course.GetStudentsByGroupNo(wantedNo);
                        break;
                    case "2.2":
                        Console.WriteLine("Butun telebelerin siyahisi");
                        course.GetAllStudents();
                        break;
                    case "2.3":
                        Console.WriteLine("Telebe elave et");
                        Console.Write("Ad: ");
                        string name = Console.ReadLine();
                        Console.Write("Soyad: ");
                        string surmane = Console.ReadLine();
                        Console.Write("Qrup nomresi: ");
                        string groupNo = Console.ReadLine();
                        Console.Write("Qrup tipi: ");
                        string type = Console.ReadLine();
                        Student student = new Student()
                        {
                            Name = name,
                            Surname = surmane,
                            GroupNo = groupNo,
                            Type = type
                        };
                        course.AddStudent(student);
                        break;
                    case "2.4":
                        //
                        Console.WriteLine("Umumi axtaris");
                        Console.Write("Axtardiginiz sozu daxil edin: ");
                        string wantedValue = Console.ReadLine();
                        course.Search(wantedValue);
                        break;
                    case "2.5":
                        Console.WriteLine("Qrup sil");
                        Console.Write("Qrup nomresi daxil edin: ");
                        string delNo = Console.ReadLine();
                        course.RemoveGroupByNo(delNo);
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
    }
}
