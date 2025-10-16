using System.Security.Cryptography.X509Certificates;

partial class Program
{
  static void DataStructures()
  {
    User pedro = new User { Name = "Pedro", Age = 33 };
    pedro.Greet();

    Point newPoint = new Point { X = 30, Y = 20 };

    Console.WriteLine($"Punto: ({newPoint.X},{newPoint.Y})");

    CellPhone cellphone = new CellPhone("Honor 400", 2025);

    Console.WriteLine($"Celular: {cellphone.Model} - {cellphone.Year}");
  }
}

class User
{
  public string? Name { get; set; }
  public int Age { get; set; }

  public void Greet()
  {
    Console.WriteLine($"Hola, soy el usuario {Name} y mi edad es {Age} años");
  }
}

struct Point
{
  public int X { get; set; }
  public int Y { get; set; }
}

record CellPhone(string Model, int Year);