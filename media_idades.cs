using System;
using System.Globalization;

namespace Programa
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo CI = CultureInfo.InvariantCulture;
            double num, nums = 0, numf = 0;

            Console.WriteLine("Digite uma idade:");
            num = double.Parse(Console.ReadLine(), CI);

            while (num >= 0)
            {
                nums += num;  
                numf++;       
                Console.WriteLine("Digite uma idade:");
                num = double.Parse(Console.ReadLine(), CI);
            }

            if (numf > 0) 
            {
                double media = nums / numf;  
                Console.WriteLine("MEDIA: " + media.ToString("F2", CI)); 
            }
            else
            {
                Console.WriteLine("Nenhuma idade válida foi digitada.");
            }
        }
    }
}
