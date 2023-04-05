using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Homework
{
    class Person
    {
        public string Family { get; set; }

        public Person(string Family)
        {
            this.Family = Family;
        }
        public static  bool operator < (Person a, Person b)
        {
            if (string.Compare(a.Family,b.Family) == -1)
                return true;
            else return false;
        }
        public static bool operator > (Person a, Person b)
        {
            if (string.Compare(a.Family, b.Family) == 1)
                return true;
            else return false;
        }
    }
}
