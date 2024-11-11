using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V._44_Inlämningsuppgift.Model;
using V._44_Inlämningsuppgift.Services;

namespace V._44_Inlämningsuppgift.Core
{
    public class MenuOptions : SchoolService
    {
        public Student RegisterNewStudentUserInput()
        {
            int studentId = NextAvailableStudentId();

            Console.WriteLine("What is your firstname?:");
            string firstName = ConvertToHighCase(Console.ReadLine());

            Console.WriteLine("What is your lastname?:");
            string lastName = ConvertToHighCase(Console.ReadLine());

            Console.WriteLine("In what city do you live?:");
            string city = ConvertToHighCase(Console.ReadLine());

            return new Student(studentId, firstName, lastName, city);
        }

            public void ChangeStudentProperties()
            {          
                Console.WriteLine("Enter student id: ");
                int studentId = Convert.ToInt32(Console.ReadLine());

                var student = GetStudent(studentId);
                bool running = true;

                while(running == true)
                    {
                
                    Console.Clear();
                    Console.WriteLine($"{student.FirstName} {student.LastName}, {student.City}");
                    Console.WriteLine("");
                    Console.WriteLine("Which property would you like to change?");
                    Console.WriteLine("1. Firstname");
                    Console.WriteLine("2. Lastname");
                    Console.WriteLine("3. City");
                    Console.WriteLine("4. Return");

                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter new Firstname: ");
                            student.FirstName = ConvertToHighCase(Console.ReadLine());
                        break;
                        
                        case 2:
                             Console.Write("Enter new Lastname: ");
                             student.LastName = ConvertToHighCase(Console.ReadLine());
                        break;
                        
                        case 3:                           
                              Console.Write("Enter new City: ");
                              student.City = ConvertToHighCase(Console.ReadLine());
                        break;
                        
                        case 4:

                             running = false;              
                                break;
                        
                        default:
                                Console.WriteLine("Invalid choice.");
                                return;
                    }
                    
                    UpdateStudent(student);
                    Console.WriteLine("Student updated!");
                }
        }

        public void StartingMenu(SchoolService school)
        {
            Console.Clear();

            Console.WriteLine("-----School-----");
            Console.WriteLine("1: Register new student");
            Console.WriteLine("2: Change student");
            Console.WriteLine("3: List all students");
            Console.WriteLine("4: End");
        }

        public string ConvertToHighCase(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return name;

            return char.ToUpper(name[0]) + name.Substring(1).ToLower();
        }

    }
}
