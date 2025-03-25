using System;
using System.Globalization;
namespace Programa
{
    class Program
    {
        public static void Numeros(double numero1, double numero2)
        {
            if (numero1 > numero2)
            {
                Console.WriteLine("CRESCENTE");
            }
            else if (numero1 < numero2)
            {
                Console.WriteLine("DECRESCENTE");
            }
            else
            {
                Console.WriteLine("SÃO IGUAIS");
            }
        }
 

        static void Main(string[] args)
        {
            CultureInfo CI = CultureInfo.InvariantCulture;
            double numero1, numero2;

            Console.WriteLine("Digite um numero:", CI.ToString() );
            numero1 = double.Parse( Console.ReadLine() );
            Console.WriteLine("Digite outro numero:", CI.ToString());
            numero2 = double.Parse(Console.ReadLine());
            Numeros(numero1, numero2 );

            while (numero1 != numero2)
            {
                Console.WriteLine("Digite um numero:", CI.ToString());
                numero1 = double.Parse(Console.ReadLine());
                Console.WriteLine("Digite outro numero:", CI.ToString());
                numero2 = double.Parse(Console.ReadLine());
                Numeros(numero1, numero2);

            }

        }
    }
}