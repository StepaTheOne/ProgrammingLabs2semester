﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryOOP
{
    internal class Student
    {
        public Guid id;
        public string firstName;
        public string lastName;
        public string middleName;
        public int age;
        public string group;

        public Student GetStudent()
        {
            var student = new Student();

            student.firstName = "Stepan";
            student.lastName = "Novikov";
            student.middleName = "Vladimirovich";
            student.age = 21;
            student.group = "PI-211";
            return student;
        }

        public void Print()
        {
            Console.WriteLine("Информация о студенте: ");
            Console.WriteLine($"Id: {id}");
            Console.WriteLine($"Имя: {firstName}");
            Console.WriteLine($"Фамилия: {lastName}");
            Console.WriteLine($"Отчество: {middleName}");
            Console.WriteLine($"Возраст: {age}");
            Console.WriteLine($"Группа: {group}");
        }
    }
}
