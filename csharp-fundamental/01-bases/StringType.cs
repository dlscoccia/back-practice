partial class Program
{
  static void ShowStringType()
  {
    string name = "Fonzi";
    string message = "Hola " + name;
    string interpolatedMessage = $"Hola {name}";

    Console.WriteLine(message);
    Console.WriteLine(interpolatedMessage);
    Console.WriteLine($"Tu nombre tiene {name.Length} letras");
    Console.WriteLine($"Tu nombre en mayusculas es: {name.ToUpper()}");
    Console.WriteLine($"Tu nombre en minusculas es: {name.ToLower()}");

    int number = 8;

    Console.WriteLine(number.ToString());

    bool isString = true;

    Console.WriteLine(isString.ToString());

  }
}