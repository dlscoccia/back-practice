partial class Program
{
  static void ShowTime()
  {
    DateTime now = DateTime.Now;
    DateTime today = DateTime.Today;
    DateTime oneWeekAgo = now.AddDays(-7);
    DateTime customDate = new DateTime(2025, 11, 3);

    DayOfWeek weekDay = now.DayOfWeek;

    Console.WriteLine($"Fecha y hora actual: {now}");
    Console.WriteLine($"Fecha actual: {today}");
    Console.WriteLine($"Hace una semana: {oneWeekAgo.ToString("dd/MM/yyy")}");
    Console.WriteLine($"Fecha personalizada: {customDate}");
    Console.WriteLine($"Día de la semana: {weekDay}");
  }
}