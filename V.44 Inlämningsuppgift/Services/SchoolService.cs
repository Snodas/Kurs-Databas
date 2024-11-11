using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V._44_Inlämningsuppgift.Core;
using V._44_Inlämningsuppgift.Model;

namespace V._44_Inlämningsuppgift.Services
{
    public class SchoolService
    {
        public SchoolService()
        {
        }
       
        public void RegisterNewStudent(Student student)
        {
            using (var dbCtx = new SchoolDbContext())
            {
                dbCtx.Students.Add(student);    

                dbCtx.SaveChanges();
            }
        }

        public Student GetStudent(int studentId)
        {
            using (var dbCtx = new SchoolDbContext())
            {
                var student = dbCtx.Students.FirstOrDefault(s => s.StudentId == studentId);

                return student;
            }            
        }

        public void UpdateStudent(Student student)
        {
            using (var dbCtx = new SchoolDbContext())
            {
                dbCtx.Update(student);
                dbCtx.SaveChanges();
            }
        }


        public int NextAvailableStudentId()
        {
            using (var dbCtx = new SchoolDbContext())
            {
                return dbCtx.Students.Any() ? dbCtx.Students.Max(s => s.StudentId) + 1 : 1;
            }
        }

        public void ListAllStudents()
        {
            using (var dbCtx = new SchoolDbContext())
            {
                var students = dbCtx.Students.ToList();

                foreach (var student in students)
                {
                    Console.WriteLine($"Student ID: {student.StudentId} Name: {student.FirstName} {student.LastName}, City: {student.City}");
                }
            }
        }


    }
}
