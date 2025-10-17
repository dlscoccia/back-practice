partial class Program
{
  static void WriteFileExample()
  {
    var filePath = "./05-Files/EjemploEscritura.txt";

    var content = "Prueba de escrituta";

    var streamWriter = new StreamWriter(filePath, append: true);
    streamWriter.WriteLine(content);
    streamWriter.WriteLine("Hora actual: " + DateTime.Now.ToString("HH:mm:ss"));

    streamWriter.Dispose();

    WriteLine("Archivo creado");
  }
}