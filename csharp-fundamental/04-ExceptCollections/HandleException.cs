partial class Program
{
  static string? amount;
  static void HandleException()
  {
    try
    {
      Write("Ingrese un monto: ");
      amount = ReadLine();

      if (string.IsNullOrEmpty(amount)) return;

      if (double.TryParse(amount, out double amountValue))
      {
        WriteLine($"El monto es: {amountValue:C}");
      }
      else
      {
        WriteLine("No se pudo convertir el texto a numero");
      }

      ValidateAge(16);
    }
    catch (DivideByZeroException)
    {
      Console.ForegroundColor = ConsoleColor.Red;
      WriteLine("Error: Division por cero");
    }
    catch (FormatException) when (amount?.Contains("$") == true)
    {
      WriteLine("No es necesario usar $");
    }
    catch (Exception ex)
    {
      WriteLine(ex.Message);
    }
    finally
    {
      WriteLine("Finally ejecutado");
    }
  }

  static void ValidateAge(int age) {
    if (age < 18)
    {
      throw new ArgumentException("Edad debe ser mayor a 18");
    }
  }
}