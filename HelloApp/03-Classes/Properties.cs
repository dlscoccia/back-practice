partial class Program
{
  static void Properties()
  {
    Animal animal = new Animal("Bosque");
    animal.Species = "Lobo";
    animal.Age = 4;

    WriteLine($"Donde vive: {animal.Habitat}, que animal es: {animal.Species}, que tiene categoria de: {animal.Category}");
  }
}

class Animal
{
  public string Species { get; set; } = "Desconocida";
  public string Category { get; } = "Vertebrado";

  private int age;
  public int Age
  {
    get { return age; }
    set
    {
      if (value < 0)
      {
        throw new ArgumentException("La edad no puede ser negativa.");
      }
      age = value;
    }
  }

  public string Habitat { get; }
  public Animal(string habitat)
  {
    Habitat = habitat;
  }
}