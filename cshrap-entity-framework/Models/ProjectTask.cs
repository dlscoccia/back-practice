using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectef.Models;

[Table("ProjectTasks")]
public class ProjectTask {
    public Guid TaskId {get; set;}
    public Guid CategoryId {get; set;}
    public string Title {get; set;}

    public string Description {get; set;}
    public Priority TaskPriority {set; get;}
    public DateTime CreationDate {get; set;}
    public virtual Category Category {set; get;}
    public string Summary {get; set;}
}

public enum Priority {
    Low, 
    Medium, 
    High
}