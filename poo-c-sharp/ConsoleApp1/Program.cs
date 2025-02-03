using System.Text;
using ConsoleApp1;
using ConsoleApp1.Models;

var flyPower = new SuperPower();
flyPower.Name = "Fly";
flyPower.Description = "Capacity to fly";
flyPower.Level = PowerLevel.LevelFour;

var superStrength = new SuperPower();
superStrength.Name = "Super Strength";
superStrength.Description = "Super Strenght power";
superStrength.Level = PowerLevel.LevelTwo;

var regeneration = new SuperPower();
regeneration.Name = "Regeneration";
regeneration.Description = "Auto Heal Power";
regeneration.Level = PowerLevel.LevelFour;

var superman = new SuperHero();

superman.Id = 1;
superman.Name = "   Superman  ";
superman.AlterEgo = "Clarck Kent";
superman.CanFly = true;

List<SuperPower> supermanPowers = new List<SuperPower>();
supermanPowers.Add(flyPower);
supermanPowers.Add(superStrength);

superman.Powers = supermanPowers;

string resultPowers = superman.UsePowers();
Console.WriteLine(resultPowers);

string resultSaveTheWorld = superman.SaveTheWorld();
Console.WriteLine(resultSaveTheWorld);

string resultSaveTheUniverse = superman.SaveTheUniverse();
Console.WriteLine(resultSaveTheUniverse);

var deadpool = new AntiHero();
deadpool.Id = 5;
deadpool.Name = "Deadpool";
deadpool.CanFly = false;
deadpool.City = "California";

List<SuperPower> deadpoolPowers = new List<SuperPower>();
deadpoolPowers.Add(regeneration);

deadpool.Powers = deadpoolPowers;

string resultDeadpoolPowers = deadpool.UsePowers();
Console.WriteLine(resultDeadpoolPowers);

string antiheroAction = "dancing with knives";

string actionResult = deadpool.AntiHeroAction(antiheroAction);
Console.WriteLine($"{actionResult}");

var printInfo = new PrintInfo();

printInfo.Print(superman);

printInfo.Print(deadpool);

enum PowerLevel
{
    LevelOne, LevelTwo, LevelThree, LevelFour
}