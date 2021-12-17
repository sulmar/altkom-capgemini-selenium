using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Parents { get; set; }

        public static Person operator + (Person man, Person woman)
        {
            Person child = new Person();

            child.Parents = man.FirstName + man.LastName + woman.FirstName + woman.LastName;

            return child;
        }
    }

    public class Tester
    {
        public void Test()
        {
            Person man = new Person();
            Person woman = new Person();

            //Person child = new Person();
            // child.Parents = man.FirstName + man.LastName + woman.FirstName + woman.LastName;

            Person child = man + woman;

            Console.WriteLine(child);


        }
    }   
}

