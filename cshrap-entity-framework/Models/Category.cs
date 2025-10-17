using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace projectef.Models;

[Table("Categories")]
public class Category {
    public Guid CategoryId {get; set;}
    public string Name {get; set;}
    public string Description {get; set;}
public int Weight {get; set;}
    [JsonIgnore]
    public virtual ICollection<ProjectTask> Tasks {get; set;}
}