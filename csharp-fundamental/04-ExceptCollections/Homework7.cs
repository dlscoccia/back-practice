/*
=====================================
Análisis de Ventas con LINQ y Excepciones
=====================================
*/
// 🏆 Ejercicio:
// Desarrollar un sistema para analizar las ventas de una empresa usando colecciones y LINQ.
// Tendrás una clase "Sale" con las siguientes propiedades:
//  - Product (public)
//  - Category (public)
//  - Amount (public)
//
// También una lista con 6 ventas ficticias.
// Lo que tendrás que desarrollar es:
// 1. Filtrar y mostrar las ventas con monto superior a 1000.
// 2. Agrupar las ventas por categoría y calcular el total de ventas por categoría.
// 3. Manejar excepciones en caso de errores al procesar los datos.

partial class Program
{
  static void SalesAnalysis()
  {
    try
    {
      List<Sale> sales = [
             new Sale("Laptop", "Electrónica", 1500),
            new Sale("Teléfono", "Electrónica", 900),
            new Sale("Silla", "Muebles", 1200),
            new Sale("Escritorio", "Muebles", 800),
            new Sale("Tablet", "Electrónica", 1300),
            new Sale("Lámpara", "Iluminación", 400)
     ];

      WriteLine("Ventas con monto mayor a 1000");

      var salesBiggerThanThousand = sales.Where(s => s.Amount > 1000);

      foreach (var item in salesBiggerThanThousand)
      {
        WriteLine($"Producto: {item.Product}, Categoria: {item.Category}, Monto: {item.Amount:C}");
      }

      WriteLine();
      WriteLine("Total de ventas por categoria:");

      var salesByCategory = sales.GroupBy(s => s.Category).Select(g => new { Category = g.Key, Sale = g.Sum(a => a.Amount) });

      foreach (var item in salesByCategory)
      {
        WriteLine($"{item.Category} - {item.Sale:C}");
      }
    }
    catch (Exception ex)
    {

      WriteLine($"Error al procesar las ventas: {ex.Message}");
    }


  }


}

class Sale
{
  public string? Product { get; set; }
  public string? Category { get; set; }
  public double Amount { get; set; }

  public Sale(string product, string category, double amount)
  {
    Product = product;
    Category = category;
    Amount = amount;
  }
}