namespace FirstApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Person p = new Person("Alan", "Alanowski", 2002);
            Console.WriteLine(p.GetName());
            Console.WriteLine(p.Surname);
            //p.Surname = "Alicja";
            Console.WriteLine(p);
            Console.WriteLine("Imie osoby " + p);
            Person p2 = new Person("Alan", "Alanowski", 2002);
            if (p == p2)
            {
                Console.WriteLine(" == True");
            }
            else
            {
                Console.WriteLine(" == False"); 
            }
            if (p.Equals(p2))
            {
                Console.WriteLine(" == True");
            }
            else
            {
                Console.WriteLine(" == False");
            }
            Student s = new Student("12344321", "Alan", "Alanowski", 2002);
            Console.WriteLine(s);
            if (p.Equals(s)) // równoważne s.Equals(p) ponieważ s nie przeładowało Equals
            {
                Console.WriteLine(" == True");
            }
            else
            {
                Console.WriteLine(" == False");
            }
            //Person[] persons = new Person[3];
            //persons[0] = p; persons[1] = p2;persons[2] = s;
            List<Person> persons = new List<Person>();
            
            persons.Add(p); persons.Add(p2); persons.Add(s);
            foreach (Person pp in persons)
            {
                Console.WriteLine(pp.Equals(p));
            }
            Console.WriteLine(persons.Count);

            HashSet<Person> set = new HashSet<Person>();
            set.Add(p); set.Add(p2); set.Add(s);
            Console.WriteLine("Teraz Sety");
            foreach (Person pp in set)
            {
                Console.WriteLine(pp.Equals(p));
            }
            Console.WriteLine(set.Count);

            Dictionary<String, Student> dict = new Dictionary<String, Student>();
            dict[s.StudentID] = s;
            s = new Student("a1234", "Janina", "Janińska", 2000);
            dict[s.StudentID] = s;
            s = new Student("1234a", "Marian", "Marian", 1998);
            dict[s.StudentID] = s;
            foreach (String id in dict.Keys)
            {
                Student s1 = dict[id];
                Console.WriteLine("{0} {1} ",id,s1);
            }
            Console.WriteLine("=========Sort=========");
            persons.AddRange(dict.Values);
            persons.Sort();
            foreach (Person pp in persons)
            {
                Console.WriteLine("{0} rokur.:{1}", pp,pp.yearOfBirth);
            }
            Console.WriteLine("=========Sort By Name=");
            persons.Sort(new PersonComparerByName());
            foreach (Person pp in persons)
            {
                Console.WriteLine(pp);
            }
            PersonComparer pc = new PersonComparer();
            persons.Sort(pc.BySurname());
            
        }
    }
}
