partial class Program
{
  static void DaysOfLife()
  {
    DateTime birthday = new DateTime(2006, 2, 5);
    TimeSpan difference = DateTime.Now - birthday;

    Console.WriteLine($"Has vivido: {difference.Days} días");
  }
}