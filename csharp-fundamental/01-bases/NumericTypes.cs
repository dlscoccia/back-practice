partial class Program
{
  static void ShowNumericTypes()
  {
    int intergerNumber = 42;
    double doubleNumber = 3.14d;
    float floatingNumber = 274f;
    long longNumber = 123_456_789_551L;
    decimal monetaryNumber = 99.99m;

    Console.WriteLine($"Entero: {intergerNumber}");
    Console.WriteLine($"Double: {doubleNumber}");
    Console.WriteLine($"Float: {floatingNumber}");
    Console.WriteLine($"Long: {longNumber}");
    Console.WriteLine($"Decimal: {monetaryNumber}");
  }
}