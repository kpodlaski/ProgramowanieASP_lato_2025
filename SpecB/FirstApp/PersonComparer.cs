using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    internal class PersonComparer
    {

        public IComparer<Person> BySurname()
        {
            return new ImplBySurname();
        }

        public IComparer<Person> ByName()
        {
            return new PersonComparerByName();
        }

        public IComparer<Person> BySurnameAndName()
        {
            return new ImplBySurnameAndName();

        }

        class ImplBySurname : IComparer<Person>
        {
            public int Compare(Person? a, Person? b)
            {
                return a.Surname.CompareTo(b.Surname);
            }
        }
        class ImplBySurnameAndName : IComparer<Person>
        {
            public int Compare(Person? a, Person? b)
            {
                int v =  a.Surname.CompareTo(b.Surname);
                if ( y ==0)
                {
                    v = a.GetName().CompareTo(b.GetName());
                }
                
                return v;                    
                }
            }
        }
    }
    }
        
    
