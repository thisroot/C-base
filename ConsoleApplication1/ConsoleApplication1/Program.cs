using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Privet!");


            int debitSum = 0;
            for(int i = 0; i<10;i++)
            {
                string debit = "";
                int debitInt;
                Console.Write("Input debit:");
                debit = Console.ReadLine();
                Console.WriteLine("Our debit" + debit);

                int.TryParse(debit, out debitInt);

                debitSum += debitInt;

            }

            Console.WriteLine();

            int creditSum = 0;
            for(int i = 0; i<10; i++)
            {
                string credit = "";
                int creditInt;
                Console.Write("Input credit:");
                credit = Console.ReadLine();
                Console.WriteLine("Our credit" + credit);

                int.TryParse(credit, out creditInt);
                creditSum += creditInt;
            }

            Console.WriteLine();

            int balance = debitSum - creditSum;
            Console.WriteLine("Our balance" + balance.ToString());
            Console.WriteLine();

            if(balance >0)
            {
                Console.WriteLine("Congratulation we are in pluse");
            } else
            {
                Console.WriteLine("Sorry our balanse in minus");
            }


            Console.ReadKey();
        }
    }
}
