using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class CNPJ
{
    private string cnpj;
    private string cnpj_sem_dv;

    public CNPJ(string input_cnpj)
    {
        try
        {
            bool cnpj_valido = ValidaFormato(input_cnpj);
            if (cnpj_valido)
            {
                cnpj = RemovePontuacao(input_cnpj);
            }
            else
            {
                throw new Exception("CNPJ não está no padrão aa.aaa.aaa/aaaa-dd (Para validação) ou aa.aaa.aaa/aaaa (Para geração do DV)");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Environment.Exit(0);
        }
    }

    private void RemoveDigitosCnpj()
    {
        if (cnpj.Length == 14)
        {
            cnpj_sem_dv = cnpj.Substring(0, cnpj.Length - 2);
        }
        else if (cnpj.Length == 12)
        {
            cnpj_sem_dv = cnpj;
        }
        else
        {
            throw new Exception("CNPJ com tamanho inválido!");
        }
    }

    private string RemovePontuacao(string input)
    {
        return string.Concat(input.Where(x => x != '.' && x != '/' && x != '-'));
    }

    public bool Valida()
    {
        RemoveDigitosCnpj();
        string dv = GeraDv();
        return $"{cnpj_sem_dv}{dv}" == cnpj;
    }

    public string GeraDv()
    {
        RemoveDigitosCnpj();
        DigitoVerificador dv1 = new DigitoVerificador(cnpj_sem_dv);
        string dv1char = dv1.Calcula().ToString();

        DigitoVerificador dv2 = new DigitoVerificador(cnpj_sem_dv + dv1char);
        string dv2char = dv2.Calcula().ToString();

        return $"{dv1char}{dv2char}";
    }

    private bool ValidaFormato(string cnpj)
    {
        return Regex.IsMatch(cnpj, @"^([A-Z]|\d){2}\.([A-Z]|\d){3}\.([A-Z]|\d){3}/([A-Z]|\d){4}(-\d{2})?$");
    }
}

public class DigitoVerificador
{
    private string cnpj;
    private List<int> pesos;
    private int digito;

    public DigitoVerificador(string input)
    {
        cnpj = input.ToUpper();
        pesos = new List<int>();
        digito = 0;
    }

    private int CalculaAscii(char caracter)
    {
        return caracter - '0';
    }

    private int CalculaSoma()
    {
        int tamanho_range = cnpj.Length;
        int num_range = (int)Math.Ceiling(tamanho_range / 8.0);
        for (int i = 0; i < num_range; i++)
        {
            pesos.AddRange(Enumerable.Range(2, 8));
        }
        pesos = pesos.Take(tamanho_range).ToList();
        pesos.Reverse();
        int sum_of_products = cnpj.Select((c, index) => CalculaAscii(c) * pesos[index]).Sum();
        return sum_of_products;
    }

    public int Calcula()
    {
        int mod_sum = CalculaSoma() % 11;

        if (mod_sum < 2)
        {
            return 0;
        }
        else
        {
            return 11 - mod_sum;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length < 2)
            {
                throw new Exception("Formato inválido do CNPJ.");
            }
            string exec = args[0].ToUpper();
            string input = args[1];

            CNPJ cnpj = new CNPJ(input);
            if (exec == "-V")
            {
                Console.WriteLine(cnpj.Valida());
            }
            else if (exec == "-DV")
            {
                Console.WriteLine(cnpj.GeraDv());
            }
            else
            {
                throw new Exception("Opção inválida passada, as válidas são: -V para validar, -DV para gerar digito validador.");
            }
            Environment.Exit(0);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Environment.Exit(0);
        }
    }
}