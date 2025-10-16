partial class Program
{
  static void ListDictionary()
  {
    List<string> names = new List<string> { "Ana", "Carlos", "Juan" };
    names.Add("Lucia");

    Console.WriteLine($"Total de nombres: {names.Count}");

    foreach (string name in names)
    {
      Console.WriteLine(name);
    }
    names.Remove("Ana");
    bool isPresent = names.Contains("Ana");

    Console.WriteLine($"Ana está en la lista?: {isPresent}");

    Dictionary<int, string> students = new Dictionary<int, string>
    {
      {1, "Ana"},
      {2, "Felipe"},
      {3, "Elena"}
    };
    foreach (var student in students)
    {
      Console.WriteLine($"ID: {student.Key} - Nombre: {student.Value}");
    }
    Console.WriteLine($"El estudiante con ID 3 es: {students[3]}");
  }
}