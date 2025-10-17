using System.Security.Cryptography.X509Certificates;

partial class Program
{
  static void EmployeeCalculator()
  {
    List<Employee> employees = new List<Employee>();

    employees.Add(new TeamLeader("Carlos", 5000));
    employees.Add(new Developer("Ana", 4000));
    employees.Add(new TeamLeader("Laura", 6000));
    employees.Add(new Developer("Pedro", 3500));

    WriteLine("Detalles de Empleados:");
  foreach (var employee in employees)
  {
      employee.ShowInfo();
  }

  }

  class Employee
  {
    protected string? Name { get; set; }
    protected double Salary { get; set; }
    protected string? Position { get; set; }

    public Employee(string name, double salary, string position)
    {
      Name = name;
      Salary = salary;
      Position = position;
    }

    public virtual double CalculatorBonus()
    {
      return Salary * 0.05;
    }

    public void ShowInfo()
    {
      WriteLine($"Empleado: {Name}, Cargo: {Position}, Salario: {Salary:C}, Bono: {CalculatorBonus():C}");
    }
  }

  class TeamLeader : Employee
  {
    public TeamLeader(string name, double salary) : base(name, salary, "Team Leader")
    {

    }
    public override double CalculatorBonus()
    {
      return Salary * 0.1;
    }
  }
  class Developer : Employee
  {
    public Developer(string name, double salary) : base(name, salary, "Developer")
    {
    }
    public override double CalculatorBonus()
    {
      return Salary * 0.07;
    }
  }
}