﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
<<<<<<< HEAD
    internal class Person : IComparable
=======
    internal class Person
>>>>>>> 8e6617f796cd5f84299663d386e44c22c0487a75
    {
        private string name;
        public String Surname { get; private set; }
        public int yearOfBirth;

        public Person(String name, String surname, int yoB) {
            this.name = name;
            this.Surname = surname;
            this.yearOfBirth = yoB;
        }

        public String GetName()
        {
            return name;
        }

        public override string ToString()
        {
            return name + " " + Surname;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Person) return false;
            Person p2 = (Person) obj;
            if (p2 == null) return false;
            if (p2 == this) return true;
            if (! p2.name.Equals(name)) return false;
            if (!p2.Surname.Equals(Surname)) return false;
            if (p2.yearOfBirth != yearOfBirth) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return yearOfBirth;
        }
<<<<<<< HEAD

        public int CompareTo(object? obj)
        {
            if (obj is not Person) return -1;
            Person p2 = (Person) obj;
            return this.yearOfBirth - p2.yearOfBirth; 
        }
=======
>>>>>>> 8e6617f796cd5f84299663d386e44c22c0487a75
    }
}
