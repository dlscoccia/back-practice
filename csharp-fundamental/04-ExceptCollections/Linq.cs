partial class Program
{
  static void Linq()
  {
    List<int> numbers = [1, 2, 3, 4, 5, 6];
    List<int> evenNumbers = [];

    var evenNumbersQuery = from num in numbers
                           where num % 2 == 0
                           select num;

    var evenNumbersMethod = numbers.Where(n => n % 2 == 0);

    /*     foreach (var number in evenNumbersMethod)
        {
          WriteLine(number);
        } */

    List<MarvelCharacter> characters = new List<MarvelCharacter>
{
  new MarvelCharacter { Name = "Peter Parker", Alias = "Spider-Man", Team = "Avengers" },
  new MarvelCharacter { Name = "Tony Stark", Alias = "Iron Man", Team = "Avengers" },
  new MarvelCharacter { Name = "Steve Rogers", Alias = "Captain America", Team = "Avengers" },
  new MarvelCharacter { Name = "Natasha Romanoff", Alias = "Black Widow", Team = "Avengers" },
  new MarvelCharacter { Name = "T'Challa", Alias = "Black Panther", Team = "Wakanda" },
  new MarvelCharacter { Name = "Stephen Strange", Alias = "Doctor Strange", Team = "Defenders" }
};

    var avengersQuery = characters.Where(character => character.Team == "Avengers");
    /*     foreach (var avenger in avengersQuery)
        {
          WriteLine(avenger.Name);
        } */

    var uppercaseNamesQuery = characters.Select(character => character.Name?.ToUpper());
    /*     foreach (var character in uppercaseNamesQuery)
        {
          WriteLine(character);
        } */

    /*     var sortedMethod = characters.OrderByDescending(c => c.Name);
        foreach (var character in sortedMethod)
        {
          WriteLine(character.Name);
        } */
    var sortedMethod = characters.OrderBy(c => c.Name);
    /*     foreach (var character in sortedMethod)
        {
          WriteLine(character.Name);
        } */

    var firstThreeMethod = characters.Take(3);
    foreach (var character in firstThreeMethod)
    {
      WriteLine(character.Name);
    }
    var firstMethod = characters.First();
    WriteLine(firstMethod.Name);
  }
}

class MarvelCharacter
{
  public string? Name { get; set; }
  public string? Alias { get; set; }
  public string? Team { get; set; }
}
