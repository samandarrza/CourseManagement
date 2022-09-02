using CourseManagementLibrary;
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
                Console.WriteLine("=====Course Management App=====");
                Console.WriteLine(" 1.1 - Qruplarin siyahisini goster");
                Console.WriteLine(" 1.2 - Yeni qrup yarat ");
                Console.WriteLine(" 1.3 - Qrup uzerinde duzelis etmek");
                Console.WriteLine(" 2.1 - Qrupdaki telebelerin siyahisini goster");
                Console.WriteLine(" 2.2 - Butun telebelerin siyahini goster");
                Console.WriteLine(" 2.3 - Telebe elave et ");
                Console.WriteLine(" 2.4 - Umumi axtarir");
                Console.WriteLine(" 2.5 - Group sil");
                Console.WriteLine(" 0 - Menudan cix");
                Console.WriteLine("===============================");
                Console.Write("Secim edin: ");
                opt = Console.ReadLine();
                Console.Clear();




                switch (opt)
                {
                    case "1.1":
                        course.ShowGroup();
                        break;
                    case "1.2":
                        Console.WriteLine("No: ");
                        string no = Console.ReadLine();
                        Console.WriteLine("Category: ");
                        string category = Console.ReadLine();
                        Group group = new Group();
                        group.No = no;
                        group.Category = category;
                        course.AddGroup(group);
                        break;
                    case "1.3":
                        //
                        break;
                    case "2.1":
                        //
                        break;
                    case "2.2":
                        //
                        break;
                    case "2.3":
                        Student student = new Student();
                        course.AddStudent(student);
                        break;
                    case "2.4":
                        //
                        break;
                    case "2.5":
                        //
                        break;
                    case "0":
                        Console.WriteLine("Programdan cixdi");
                        break;
                    default:
                        Console.WriteLine("Yanlis secim etdiniz!");
                        break;
                }

            } while (opt != "0");

        }
    }
}
