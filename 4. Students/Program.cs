using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Students
{
    class Program
    {
        class Student
        {
          
           public string FirstName { get; set; }
            public string LastName { get; set; }
            public double Grade { get; set; }
        }
        static void Main(string[] args)
        {
            int countOfStudents = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();
            for (int i = 0; i < countOfStudents; i++)
            {
                string[] token = Console.ReadLine().Split(" ");
                Student student = new Student();

                string firstName = token[0];
                student.FirstName = firstName;
                student.LastName = token[1];
                student.Grade = double.Parse(token[2]);
                students.Add(student);

            }
            students = students.OrderByDescending(student => student.Grade).ToList();
            foreach (Student student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }
        }
    }
}
