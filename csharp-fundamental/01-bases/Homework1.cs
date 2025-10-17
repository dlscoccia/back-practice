partial class Program
{
  static void SalesReport()
  {
    string product = "Laptop";
    int quantitySold = 3;
    double unitPrice = 850.99;
    double totalAmount = quantitySold * unitPrice;

    Console.WriteLine($"Producto: {product}");
    Console.WriteLine($"Cantidad vendida: {quantitySold}");
    Console.WriteLine($"Total generado: {totalAmount:C}");
  }
}