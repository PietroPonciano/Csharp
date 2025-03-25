using System;
using System.Globalization;
namespace Programa
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo CI = CultureInfo.InvariantCulture;
            double a, b, c, d;
            double x, y;

            Console.WriteLine("Digite o valor de A:");
            a = double.Parse(Console.ReadLine(), CI);
            Console.WriteLine("Digite o valor de B:");
            b = double.Parse(Console.ReadLine(), CI); 
            Console.WriteLine("Digite o valor de C:");
            c = double.Parse(Console.ReadLine(), CI);

           x = (-b + Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / 2*a;
           y = (-b - Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / 2 * a;

            Console.WriteLine("O X1 sera:" + x);
            Console.WriteLine("O X2 sera:" + y);


        }
    }
}