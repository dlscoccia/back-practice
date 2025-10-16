partial class Program
{
  static void DirectoryExample()
  {
    var directoryPath = "./05-Files";

    Directory.CreateDirectory($"{directoryPath}/Example");

    if (Directory.Exists($"{directoryPath}/Example"))
    {
      WriteLine("Directory Exists");
    }

    Directory.Delete($"{directoryPath}/Example", recursive: true);

  }
}