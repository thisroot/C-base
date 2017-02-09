using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите тип машины");
            Console.WriteLine("VAZ - 2105");
            Console.WriteLine("Lambo - Lamborgini");
            Console.WriteLine("Ferarri - Ferarri");

            string type = Console.ReadLine();

            // полиморфизм
            Car chosenCar = GetCarByType(type);

            Console.WriteLine();
            Console.WriteLine("Вы выбрали:");
            Console.WriteLine(chosenCar.ToString());

            Console.WriteLine("Поехали");
            chosenCar.Drive();
            Console.WriteLine(chosenCar.ToString());

            if(chosenCar is ITurbo)
            {
                Console.WriteLine("Машина турбирована");
                ((Lamborgini)chosenCar).Turbo();
            }

            Console.ReadKey();
        }

        static Car GetCarByType(string type)
        {
            switch(type)
            {
                case "VAZ":
                    return new Vaz();
                case "Lambo":
                    return new Lamborgini();
                case "Ferarri":
                    return new Ferrari();
                default:
                    return null;
            }
        }
    }
}
