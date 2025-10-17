partial class Program
{
  static void TestingClass()
  {
    Vehicle toyota = new Vehicle();
    toyota.Brand = "Toyota";
    toyota.Model = "Yaris";
    toyota.Year = 2025;
    toyota.ShowInfo();

    Vehicle honda = new Vehicle { Brand = "Honda", Model = "Civic", Year = 2022 };
    honda.ShowInfo();
    Vehicle peugeot = new Vehicle("Peugeot", "208", 2024);
    peugeot.ShowInfo();
  }

}

class Vehicle
{
  public string? Brand { get; set; }
  public string? Model { get; set; }
  public int Year { get; set; }

  public Vehicle(string brand, string model, int year)
  {
    Brand = brand;
    Model = model;
    Year = year;
  }

  public Vehicle() { }

  public void ShowInfo()
  {
    WriteLine($"Este vehículo es un {Brand} {Model} del año {Year}");
  }
}