using System;
using System.IO;
using System.Threading;

namespace ConsoleClient
{
    class Printer : IDisposable
    {
        public const string filename = "printer.txt";

        public void Print(string content)
        {
            File.WriteAllText(filename, content);           

            Console.WriteLine($"Printing {content}...");

            Thread.Sleep(TimeSpan.FromSeconds(3));

            throw new Exception("No paper!");

            Console.WriteLine("Printed.");
          
        }

       
        // Służy do zwalniania niezarządalnych zasobów
        // (np. połączenia do bazy danych, usuwania plików, zamykania połączeń HTTP, zwalniania bibliotek dll)
        public void Dispose()
        {
            File.Delete(filename);
        }
    }
}
