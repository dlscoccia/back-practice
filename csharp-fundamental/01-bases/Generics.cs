partial class Program
{
  static void Generics()
  {
    string[] names = ["Juan", "Luis", "Diana"];
    int[] numbers = [1, 2, 3, 4];

    WriteLine($"Tamaño del arreglo númerico: {GetIntArrayLength(numbers)}");
    WriteLine($"Tamaño del arreglo de nombres: {GetStringArrayLength(names)}");

    static int GetIntArrayLength(int[] array)
    {
      return array.Length;
    }
    static int GetStringArrayLength(string[] array)
    {
      return array.Length;
    }

    static int GetArrayLength<T>(T[] array)
    {
      return array.Length;
    }
    WriteLine($"Tamaño del arreglo númerico genérico: {GetArrayLength(numbers)}");
    WriteLine($"Tamaño del arreglo de nombres genérico: {GetArrayLength(names)}");

    Box<int> numberBox = new Box<int> { Content = 50 };
    Box<string> stringBox = new Box<string> { Content = "Texto" };

    numberBox.Show();
    stringBox.Show();
  }
}

class Box<T>
{
  public T? Content { get; set; }

  public void Show()
  {
    WriteLine($"Contenido: {Content}");
  }
}