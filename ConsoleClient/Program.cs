using System;
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
            IDisposableTest();

            // UsingNamespacesTest();

            // SqlConnectionTest();
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
}
