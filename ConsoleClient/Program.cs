using Capgemini.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using Alt = Altkom.Models;
using Cpm = Capgemini.Models;

namespace ConsoleClient
{


    class Program
    {
        static void Main(string[] args)
        {
            OperatorOverloadingTest();
            ShortCheckNullTest();
            ShortIfTest();
            PolimorphismTest();
            UsingNamespacesTest();
            IDisposableTest();
            SqlConnectionTest();
        }

        private static void ShortIfTest()
        {
            Employee employee = new Employee { Salary = 200 };
            string result;

            // Zamiast 
            if (employee.Salary > 100)
            {
                result = "dużo";
            }
            else
            {
                result = "mało";
            }


            // Możemy napisać tak:
            string result2 = employee.Salary > 100 ? "dużo" : "mało";
        }

        private static void ShortCheckNullTest()
        {
            Employee employee = new Employee();

            // Zamiast takiego kodu:
            //if (employee!=null)
            //   if (employee.ShipAddress!=null)
            //        Console.WriteLine(employee.ShipAddress.City);

            // Możemy napisać tak:
            Console.WriteLine(employee?.ShipAddress?.City);
        }

        // Przykład przeciążania operatorów
        private static void OperatorOverloadingTest()
        {
            Person man = new Employee { FirstName = "John", LastName = "Smith", Salary = 100 };
            Person woman = new Person { FirstName = "Ann", LastName = "Smith" };

            // Dzięki przeciążaniu operatorów zamiast pisania wielokrotnie takiego samego kodu:
            // Person child = new Person();
            // child.Parents = man.FirstName + man.LastName + woman.FirstName + woman.LastName;

            // możemy napisać tak:
            Person child = man + woman;

            Console.WriteLine(child);


        }

        private static void PolimorphismTest()
        {
            Person person1 = new Employee { FirstName = "John", LastName = "Smith", Salary = 100 };
            Person person2 = new Person { FirstName = "Ann", LastName = "Smith" };

            ICollection<Person> people = new List<Person>();
            people.Add(person1);
            people.Add(person2);

            foreach (var person in people)
            {
                // W przypadku braku poliformizmu
                //if (person.GetType() == typeof(Person))
                //{
                //    person.DoWork();
                //}
                //else if (person.GetType() == typeof(Employee))
                //{
                //    Employee employee = (Employee)person;
                //    employee.DoWork();
                //}

                person.DoWork();
            }
        }

        private static void IDisposableTest()
        {
            try
            {
                using (Printer printer2 = new Printer())
                {

                    printer2.Print("Hello Selenium!");

                } // <- niejawne wywołanie metody Dispose

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void IDisposableTest1()
        {
            using (Printer printer = new Printer())
            {
                printer.Print("Hello Selenium!");
            } // <- niejawne wywołanie metody Dispose
        }

        private static void IDisposableTest2()
        {
            using Printer printer = new Printer();            

            printer.Print("Hello Selenium!");

        }  // <- niejawne wywołanie metody Dispose


        private static void TryFinallyTest()
        {
            Printer printer = new Printer();

            try
            {
                printer.Print("Hello Selenium!");
            }
            finally
            {
                printer.Dispose();
            }
        }

        private static void SqlConnectionTest()
        {
            string connectionString = "...";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM customers"; // SQL
                command.ExecuteReader();
            }

        }

        private static void UsingNamespacesTest()
        {
            Cpm.Customer sourceCustomer = new Cpm.Customer();
            sourceCustomer.FirstName = "John";
            sourceCustomer.LastName = "Smith";

            Alt.Customer targetCustomer = new Alt.Customer();
            targetCustomer.FullName = $"{sourceCustomer.FirstName} {sourceCustomer.LastName}";
        }
    }
}

namespace Altkom.Models
{
    public class Customer
    {
        public string FullName { get; set; }
    }
}

namespace Capgemini.Models
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Person : IEnumerable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // virtual - włącza Polimorfizm (wielopostaciowość)
        //public virtual void DoWork() 
        //{
        //    Console.WriteLine("Working for free");
        //}

        public string Parents { get; set; }

        // Przeciążanie operatorów
        public static Person operator +(Person man, Person woman)
        {
            Person child = new Person();

            child.Parents = man.FirstName + man.LastName + woman.FirstName + woman.LastName;

            return child;
        }

        public void DoWork()
        {
            Console.WriteLine("Working for free");
        }

        public IEnumerable<Person> Children { get; set; }

        public IEnumerator GetEnumerator()
        {
            return Children.GetEnumerator();            
        }
    }

    public partial class Employee : Person
    {
        public decimal Salary { get; set; }

        //public override void DoWork()
        //{
        //    Console.WriteLine($"Working for salary {Salary}");
        //}

        public Address ShipAddress { get; set; }
        

        public new void DoWork()
        {
            Console.WriteLine($"Working for salary {Salary}");
        }              
    }

    public partial class Employee : Person
    {
        // Auto generated
        public void DoAutoGeneratedWork()
        {
            // ...
        }
    }

    public class Address
    {
        public string City { get; set; }
    }
}
