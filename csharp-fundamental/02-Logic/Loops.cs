partial class Program
{
  static void Loops()
  {
    int counter = 1;
    while (counter <= 5)
    {
      WriteLine($"Iteración: {counter}");
      counter++;
    }

    int number = 0;

    do
    {
      WriteLine($"Número: {number}");
      number++;
    } while (number < 3);

    for (int i = 0; i <= 5; i++)
    {
      WriteLine($"Número for: {i}");
    }

    string[] fruits = ["Manzana", "Pera", "Piña"];

    foreach (var fruit in fruits)
    {
      WriteLine(fruit);
    }

    List<string> names = ["Pedro", "Luis", "Maria"];

    foreach (var name in names)
    {
      WriteLine(name);
    }
  }
}