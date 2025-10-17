partial class Program
{
  static void PathExample()
  {
    var filePath = "./05-Files/Copia.txt";
    var fileName = Path.GetFileName(filePath);
    var fileExtension = Path.GetExtension(filePath);
    var directoryName = Path.GetDirectoryName(filePath);
    var combinedPath = Path.Combine("C:", "User", "Documents", "Ejemplo.txt");
    var fullFilePath = Path.GetFullPath(filePath);

    WriteLine($"fileName - {fileName}");
    WriteLine($"fileExtension - {fileExtension}");
    WriteLine($"directoryName - {directoryName}");
    WriteLine($"combinedPath - {combinedPath}");
    WriteLine($"fullFilePath - {fullFilePath}");
  }
}