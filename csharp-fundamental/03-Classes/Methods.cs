using System.IO.Compression;

partial class Program
{
  static void Methods()
  {
    Car car = new Car { Model = "Yaris", Year = 2010 };
    WriteLine(car.ShowInfo());
    car.ShowMessage();
    car.ShowMessage("Cambiando de modélo");
    car.ChangeModel("Elantra");
    WriteLine(car.ShowInfo());
    Car.GeneralInfo();


    Car sportCar = new("M5", 2023);
    WriteLine(sportCar.ShowInfo());

    Car collectionCar = new Car { Model = "Cadillac", Year = 1980 };
    WriteLine(collectionCar.ShowInfo());

    List<Car> cars = new()
    {
      new Car(){Model ="Mustang", Year =1963},
      new Car(){Model ="Palio", Year =2019},
      new Car(){Model ="Ecosport", Year =2003},
    };

    WriteLine("Listado de autómoviles: ");
    foreach (var item in cars)
    {
      WriteLine(item.ShowInfo());
    }
  }
}

class Car
{
  public string? Model { get; set; }
  public int? Year { get; set; }

  public Car(string model, int year)
  {
    Model = model;
    Year = year;
  }

  public Car() { }

  ~Car()
  {
    WriteLine("Destructor");
  }

  public void ChangeModel(string newModel)
  {
    Model = newModel;
  }

  public string ShowInfo()
  {
    return $"Automóvil: {Model}, Año: {Year}";
  }

  public void ShowMessage() => WriteLine("Este es un automóvil");
  public void ShowMessage(string message) => WriteLine(message);

  public static void GeneralInfo()
  {
    WriteLine("El automóvil es uno de los transportes más populares");
  }
}