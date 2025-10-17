partial class Program
{
  static void ProductSalesDemo()
  {
    Inventory inventory = new();
    Product laptop = new Product("Laptop", 1200.99, 5);
    Product mouse = new Product("Mouse", 20.49, 8);

    inventory.AddProduct(laptop);
    inventory.AddProduct(mouse);

    inventory.ShowInventory();

    laptop.Sell(4);
    inventory.ShowInventory();
    laptop.Sell(4);
  }

  static void BusFleet()
  {
    Fleet fleet = new();
    Bus mercedes = new("Mercedes", "Busi", 2010, 120000, 8000);
    Bus yutong = new("Yutong", "Yutongsito", 2014, 73500, 6000);
    Bus volkswagen = new("Volkswagen", "M85", 2018, 103000, 2500);

    fleet.AddBus(mercedes);
    fleet.AddBus(yutong);
    fleet.AddBus(volkswagen);

    fleet.ShowFleet();

    mercedes.Drive(5000);
    yutong.Drive(5000);
    volkswagen.Drive(5000);

    WriteLine("Despues de 5000km");
    fleet.ShowFleet();


  }

  class Bus
  {
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public int Year { get; set; }
    public double Price { get; set; }
    public int TotalKilometers { get; set; }

    public Bus(string brand, string model, int year, double price, int totalKilometers)
    {
      Brand = brand;
      Model = model;
      Year = year;
      Price = price;
      TotalKilometers = totalKilometers;
    }

    public void Drive(int kilometers)
    {
      TotalKilometers += kilometers;
    }

    public void ShowPrice()
    {
      WriteLine($"El precio de este bus es: {Price}");
    }
  }

  class Fleet
  {
    List<Bus> fleet = new List<Bus>();

    public void AddBus(Bus bus)
    {
      fleet.Add(bus);
    }

    public void ShowFleet()
    {
      foreach (var bus in fleet)
      {
        WriteLine($"Marca: {bus.Brand}, Modelo: {bus.Model}, Año: {bus.Year}, Kilometraje: {bus.TotalKilometers}");
      }
    }
  }

  class Product
  {
    public string? Name { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }

    public Product(string name, double price, int stock)
    {
      Name = name;
      Price = price;
      Stock = stock;
    }

    public void Showinfo()
    {
      WriteLine($"Producto: {Name}, Precio: {Price}, Stock: {Stock}");
    }

    public bool Sell(int quantity)
    {
      if (quantity <= Stock)
      {
        Stock -= quantity;
        WriteLine($"Venta realizada: {quantity} unidades de {Name}");
        return true;
      }
      WriteLine($"Stock insuficiente para {Name}");
      return false;
    }
  }

  class Inventory
  {
    private List<Product> products = new List<Product>();

    public void AddProduct(Product product)
    {
      products.Add(product);
    }

    public void ShowInventory()
    {
      WriteLine("Inventario de productos");
      foreach (var product in products)
      {
        product.Showinfo();
      }
    }
  }
}