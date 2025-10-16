using System.Globalization;

partial class Program
{
  static void DaysUntilNextBirthday()
  {
    Console.WriteLine("Introduce tu fecha de nacimiento (dd/mm/aaaa): ");
    string birthdayDateString = Console.ReadLine()!;
    DateTime birthday = DateTime.ParseExact(birthdayDateString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
    DateTime currentDate = DateTime.Now.Date;

    DateTime nextBirthday = new DateTime(currentDate.Year, birthday.Month, birthday.Day);

    if (nextBirthday < currentDate)
    {
      nextBirthday = nextBirthday.AddYears(1);
    }

    int dayRemaining = (nextBirthday - currentDate).Days;

    Console.WriteLine($"Te faltan {dayRemaining} días para tu proximo cumpleaños");
  }
}