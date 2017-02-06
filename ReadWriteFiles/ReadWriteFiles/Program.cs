using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadWriteFiles
{
    class Program
    {
        static void Main(string[] args)
        {

            DirectoryInfo di = new DirectoryInfo("Data");
            if(di.Exists)
            {
                di.Delete(true);
            }

            di.Create();
            StreamWriter sw  = File.CreateText("Data\\money.txt");

            sw.WriteLine("Privet!");

            int debitSum = 0;
            for (int i = 0; i < 10; i++)
            {
                string debit = "";
                int debitInt;
                Console.Write("Input debit:");
                debit = Console.ReadLine();
                Console.WriteLine("Our debit" + debit);

                int.TryParse(debit, out debitInt);

                debitSum += debitInt;

            }

            sw.WriteLine();

            int creditSum = 0;
            for (int i = 0; i < 10; i++)
            {
                string credit = "";
                int creditInt;
                Console.Write("Input credit:");
                credit = Console.ReadLine();
                Console.WriteLine("Our credit" + credit);

                int.TryParse(credit, out creditInt);
                creditSum += creditInt;
            }

            sw.WriteLine();


            int balance = debitSum - creditSum;
            sw.WriteLine("Our balance" + balance.ToString());
            sw.WriteLine();

            if (balance > 0)
            {
                sw.WriteLine("Congratulation we are in pluse");
            }
            else
            {
                sw.WriteLine("Sorry our balanse in minus");
            }

            sw.Close();
            Console.ReadKey();
    }
    }
}
