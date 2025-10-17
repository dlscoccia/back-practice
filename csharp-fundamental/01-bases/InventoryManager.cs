partial class Program
{
  static void InventoryManager()
  {
    string[] products = ["Monitor", "Mouse", "Teclado"];
    int[] stock = [10, 25, 30];
    double[] prices = [250.5, 20.99, 45.00];

    Console.WriteLine("1. Comprar producto");
    Console.WriteLine("2. Salir");
    Console.WriteLine("\nIngrese una opción:");

    int option = int.Parse(Console.ReadLine()!);

    if (option == 2)
    {
      Console.WriteLine("Gracias por su visita");
      return;
    }

    Console.WriteLine("Inventario de Productos");
    Console.WriteLine("-----------------------");

    for (int i = 0; i < products.Length; i++)
    {
      Console.WriteLine($"Producto: {products[i]} - Stock: {stock[i]} - Precio: {prices[i]}");
    }

    Console.WriteLine("\nIngrese el producto que desea comprar:");
    string? searchedProduct = Console.ReadLine();
    Console.WriteLine("\nIngrese la cantidad que desea comprar:");
    int quantity = int.Parse(Console.ReadLine()!);

    for (int i = 0; i < products.Length; i++)
    {
      if (products[i].Equals(searchedProduct, StringComparison.OrdinalIgnoreCase))
      {
        if (quantity <= stock[i])
        {
          double total = quantity * prices[i];
          Console.WriteLine($"Compra exitososa. El total a pagar: {total}");
          stock[i] = stock[i] - quantity;
          Console.WriteLine($"Stock restante para el producto {products[i]} es: {stock[i]}");
        }
        else
        {
          Console.WriteLine("No hay suficiente stock");
        }

      }
    }
  }
}