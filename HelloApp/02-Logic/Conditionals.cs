partial class Program
{
  static void Conditionals()
  {
    int age = 19;
    if (age >= 18)
    {
      WriteLine("Eres mayor de edad");
    }
    else
    {
      WriteLine("Eres menor de edad");
    }

    int day = 4;

    switch (day)
    {
      case 1:
        WriteLine("Lunes");
        break;
      case 2:
        WriteLine("Martes");
        break;
      case 3:
        WriteLine("Miercoles");
        break;

      default:
        WriteLine("Día no valido");
        break;
    }

    string dayMessage = day switch
    {
      1 => "Lunes",
      2 => "Martes",
      3 => "Miercoles",
      _ => "Día no valido"
    };
    WriteLine(dayMessage);
  }
}