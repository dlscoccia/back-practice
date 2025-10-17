partial class Program
{
  static void FileExample()
  {
    string path = "./05-Files/Ejemplo.txt";
    var content = File.ReadAllText(path);

    WriteLine(content);

    var lines = File.ReadAllLines(path);
    foreach (var line in lines)
    {
      WriteLine(line);
    }

    File.Copy(path, "./05-Files/Copia.txt", overwrite: true);

    File.Delete(path);
  }
}