﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    internal class Student : Person
    {
        public String StudentID { get; set; }

        public Student(String studentID, String name, String surname, int yoB) : base(name, surname, yoB)
        {
            StudentID = studentID;
        }

        public override string ToString()
        {
            return base.ToString() + "Numer legitymacji:"+StudentID;
        }

        public override bool Equals(object? obj)
        {
            return obj is Student student &&
                   base.Equals(obj) &&
                   Surname == student.Surname &&
                   yearOfBirth == student.yearOfBirth &&
                   StudentID == student.StudentID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Surname, GetName(), yearOfBirth, StudentID);
        }
    }
}
