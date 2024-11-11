using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using V._44_Inlämningsuppgift.Model;
using V._44_Inlämningsuppgift.Services;

namespace V._44_Inlämningsuppgift.Core
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var dbCtx = new SchoolDbContext())
            {

                var school = new SchoolService();
                var menu = new MenuOptions();

                bool programRunning = true;

                while (programRunning == true)
                {
                    menu.StartingMenu(school);

                    int userInput = Convert.ToInt32(Console.ReadLine());

                    switch (userInput)
                    {
                        case 1:

                            var newStudent = menu.RegisterNewStudentUserInput();
                            school.RegisterNewStudent(newStudent);
                            Console.ReadKey();

                            break;

                        case 2:

                            menu.ChangeStudentProperties();
                            Console.ReadKey();

                            break;

                        case 3:

                            school.ListAllStudents();
                            Console.ReadKey();

                            break;

                        case 4:

                            programRunning = false;

                            break;
                    }
                }
            }

           






        }
    }
}
