using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using ExercLinq01.Entities;

namespace ExercLinq01
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Employee> employees = new List<Employee>();

                Console.WriteLine("Entre com o caminho do arquivo: ");
                string path = Console.ReadLine();

                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] fields = sr.ReadLine().Split(',');
                        string name = fields[0];
                        string email = fields[1];
                        double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);
                        employees.Add(new Employee(name, email, salary));
                    }
                }

                Console.WriteLine("Insiria um valor de parâmetro de classificação: ");
                string valueUser = Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine($"Email dos funcionários cujo salário é maior que {valueUser}: ");

                var emailList = employees.Where(e => e.Salary > double.Parse(valueUser, CultureInfo.InvariantCulture))
                                         .OrderBy(e => e.Email)
                                         .Select(e => e.Email);

                foreach (var email in emailList)
                {
                    Console.WriteLine(email);
                }

                Console.WriteLine("Soma dos Salários cujo nome começa com a letra J: ");
                var sumSalaryJ = employees.Where(s => s.Name[0] == 'J').Sum(s => s.Salary);

                Console.WriteLine(sumSalaryJ.ToString("F2", CultureInfo.InvariantCulture));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Um erro ocorreu: ");
                Console.WriteLine(ex.Message);
            }

        }
    }
}