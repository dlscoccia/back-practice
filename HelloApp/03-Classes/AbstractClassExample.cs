partial class Program
{
  static void AbstractClassExample()
  {
    HomeAppliance myWasher = new WashingMachine { Brand = "Samsung" };
    Microwave myMicrowave = new Microwave { Brand = "LG" };

    myWasher.ShowBrand();
    myWasher.TurnOn();

    myMicrowave.ShowBrand();
    myMicrowave.TurnOn();
  }
}

abstract class HomeAppliance
{
  public string? Brand { get; set; }

  public abstract void TurnOn();

  public void ShowBrand()
  {
    WriteLine($"La marca del electrodomestico es: {Brand}");
  }
}

class WashingMachine : HomeAppliance
{
  public override void TurnOn()
  {
    WriteLine("Iniciado el ciclo de lavado");
  }
}
class Microwave : HomeAppliance
{
  public override void TurnOn()
  {
    WriteLine("Iniciado el ciclo de descongelado");
  }
}