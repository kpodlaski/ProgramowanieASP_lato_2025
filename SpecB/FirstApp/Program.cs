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

        }
    }
}
