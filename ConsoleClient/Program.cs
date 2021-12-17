using Capgemini.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using Alt = Altkom.Models;
using Cpm = Capgemini.Models;

namespace ConsoleClient
{

    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();

            foreach(Person person in employee)
            {

            }

            //if (employee!=null)
             //   if (employee.ShipAddress!=null)
            //        Console.WriteLine(employee.ShipAddress.City);

            Console.WriteLine(employee?.ShipAddress?.City);

            //if (employee != null and employee.ShipAddress != null)
            //        Console.WriteLine(employee.ShipAddress.City);

            string result;

            //if (employee.Salary > 100)
            //{
            //    result = "dużo";
            //}
            //else
            //{
            //    result = "mało";
            //}

            //string result2 = employee.Salary > 100 ? "dużo" : "mało";

            // PolimorphismTest();

            // IDisposableTest();

            // UsingNamespacesTest();

            // SqlConnectionTest();
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
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM customers"; // SQL
            command.ExecuteReader();

            connection.Close();
            connection.Dispose();
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

    public class Employee : Person
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

    public class Address
    {
        public string City { get; set; }
    }
}
