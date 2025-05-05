using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    internal class PersonComparerByName : IComparer<Person>
    {
        public int Compare(Person? x, Person? y)
        {
            return x.GetName().CompareTo(y.GetName());
        }
    }
}
