using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter file path: ");
            string filePath = Console.ReadLine();

            ContactManager cm = new ContactManager();

            try
            {
                cm.ReadFromFile(filePath);
            }
            catch(BusinessLogicExeption ex)
            {
                Console.WriteLine(ex.BusinessLogicMessage);
            }

            Console.WriteLine("\nEnteries");

            foreach(ContactEntery ce in cm.Enteries)
            {
                Console.WriteLine(ce.ToString());
            }
      
            Console.WriteLine();
            Console.WriteLine(cm.Log);
            Console.ReadKey();

        }
    }
}
