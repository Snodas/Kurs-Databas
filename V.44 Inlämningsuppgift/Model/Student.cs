using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V._44_Inlämningsuppgift.Model
{
    public class Student(int studentId, string firstName, string lastName, string city)
    {
        public int StudentId { get; set; } = studentId;
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;
        public string City { get; set; } = city;
    }
}
