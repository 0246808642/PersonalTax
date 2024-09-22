using PersonalTax.Entities;
using System.Globalization;

namespace PersonalTax
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> list = new List<TaxPayer>();
            Console.Write("Enter the number of tax payers: ");
            int payers = int.Parse(Console.ReadLine());

            for (int i = 0; i <= payers; i++)
            {
                Console.WriteLine($"Tax payer #{i} data:");
                Console.Write("Individual or company (i/c)? ");
                char ch = char.Parse(Console.ReadLine());
                if (ch == 'i' || ch == 'I')
                {
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Anual income: ");
                    double income = double.Parse(Console.ReadLine());
                    Console.Write("Health expenditures: ");
                    double healt = double.Parse(Console.ReadLine());
                    list.Add(new Individual(name, income, healt));
                }
                else
                {
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Anual income: ");
                    double income = double.Parse(Console.ReadLine());
                    Console.Write("Number of employees: ");
                    int employee = int.Parse(Console.ReadLine());
                    list.Add(new Company(name, income, employee));
                }

            }
            double sum = 0.0;
            Console.WriteLine();
            Console.WriteLine("TAXES PAID:");
            foreach (TaxPayer tp in list)
            {
                double tax = tp.Tax();
                Console.WriteLine(tp.Name + ": $ " + tax.ToString("F2", CultureInfo.InvariantCulture));
                sum += tax;
            }

            Console.WriteLine();
            Console.WriteLine("TOTAL TAXES: $ " + sum.ToString("F2", CultureInfo.InvariantCulture));


        }
    }
}
