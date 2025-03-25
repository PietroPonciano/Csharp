using System;
using System.Globalization;
namespace Programa
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo CI = CultureInfo.InvariantCulture;
            double nota1, nota2, notafinal ;
            Console.Write("Digite a primeira nota: ");
            nota1 = double.Parse(Console.ReadLine());
            Console.Write("Digite a segunda: ");
            nota2 = double.Parse(Console.ReadLine());

            notafinal = nota1 + nota2;

            if (notafinal >= 70){
                Console.WriteLine("A nota final sera:" + notafinal);
                Console.WriteLine("APROVADO");
            }
            else
            {
                Console.WriteLine("A nota final sera:" + notafinal);
                Console.WriteLine("REPROVADO");
            }

            
                 

        }
    }
}