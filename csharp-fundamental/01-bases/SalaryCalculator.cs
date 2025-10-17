partial class Program
{
  static void SalaryCalculator()
  {
    Console.WriteLine("Calculadora de salario");
    Console.WriteLine();



    Console.Write("Ingrese su nombre: ");
    string? name = Console.ReadLine();

    Console.Write("Ingrese el número de horas trabajadas: ");
    double hours = double.Parse(Console.ReadLine()!);

    Console.Write("Ingrese el salario por hora: ");
    double rate = double.Parse(Console.ReadLine()!);

    double salary = hours * rate;

    Console.WriteLine($"El salario para {name} es de {salary}");

  }
}