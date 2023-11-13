using System.Globalization;
using PooCSharp_2.Entities;
using PooCSharp_2.Entities.enums;


namespace PooCSharp_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Insira o nome do Departamento: ");
            string dptNome = Console.ReadLine();
            Departament dept = new Departament(dptNome);

            Console.Write("Insira os dados do Trabalhador: ");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Level (Juniro/MidLevel/Senior) :");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());

            Console.Write("Salario Base: ");
            double salarioBase = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Worker worker = new Worker(nome, level, salarioBase, dept);

            Console.WriteLine("Quantos contratos para este trabalhador?");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i < n; i++)
            {
                Console.WriteLine($"Entre o contrato #{i}: ");
                Console.WriteLine("Data (DD/MM/YYYY)");
                DateTime date = DateTime.Parse(Console.ReadLine());
                
                Console.WriteLine("Valor por hora: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                
                Console.WriteLine("Duração (Horas): ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);
            }

            Console.WriteLine();
            Console.Write("Insira o Mes e o Ano para calcular a Renda (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine("Nome" + worker.Name);
            Console.WriteLine("Departamento: " + worker.Departament.Name);
            Console.WriteLine("Renda:" + monthAndYear + ":" +
                              worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}