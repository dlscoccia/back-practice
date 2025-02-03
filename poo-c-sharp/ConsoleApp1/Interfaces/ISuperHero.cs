using System.Text;


namespace ConsoleApp1.Interfaces
{
    internal interface ISuperHero
    {
        int Id { get; set; }
        string Name { get; set; }
        string AlterEgo { get; set; }

        string GetSuperHeroe()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Id: {Id}");
            sb.AppendLine($"Nombre: {Name}");
            sb.AppendLine($"Identidad secreta: {AlterEgo}");
            return sb.ToString();
        }
    }
}
