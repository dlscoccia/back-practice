using Microsoft.EntityFrameworkCore;
using projectef.Models;

namespace projectef;

public class TasksContext : DbContext {
    public DbSet<Category> Categories {get; set;}
    public DbSet<ProjectTask> ProjectTasks {get; set;}

    public TasksContext(DbContextOptions<TasksContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        List<Category> categoryInit = new List<Category>();
        categoryInit.Add(new Category() {CategoryId = Guid.Parse("d7af7863-3c92-41b0-9c09-9ccc2e60c369"), Name = "Pending Tasks", Weight = 10, Description = "To do tasks" });
        categoryInit.Add(new Category() {CategoryId = Guid.Parse("d7af7863-3c92-41b0-9c09-9ccc2e60c370"), Name = "Done Tasks", Weight = 30, Description = "Already done tasks" });

        modelBuilder.Entity<Category>(category => {
            category.ToTable("Category");
            category.HasKey(prop => prop.CategoryId);
            category.Property(prop => prop.Name).IsRequired().HasMaxLength(100);
            category.Property(prop => prop.Description).HasMaxLength(250);
            category.Property(prop => prop.Weight).IsRequired();
            category.HasData(categoryInit);
        });

        List<ProjectTask> projectTasksInit = new List<ProjectTask>();
        projectTasksInit.Add(new ProjectTask() {TaskId = Guid.Parse("d7af7863-3c92-41b0-9c09-9ccc2e60c400"), CategoryId = Guid.Parse("d7af7863-3c92-41b0-9c09-9ccc2e60c369"), TaskPriority = Priority.Medium, Title = "Cook dinner", CreationDate = DateTime.Now, Description = "Custom Description"});
        
        projectTasksInit.Add(new ProjectTask() {TaskId = Guid.Parse("d7af7863-3c92-41b0-9c09-9ccc2e60c401"), CategoryId = Guid.Parse("d7af7863-3c92-41b0-9c09-9ccc2e60c370"), TaskPriority = Priority.High, Title = "Feed the cat", CreationDate = DateTime.Now, Description = "Custom Description"});

        modelBuilder.Entity<ProjectTask>(projectTask => {
            projectTask.ToTable("ProjectTask");
            projectTask.HasKey(prop => prop.TaskId);
            projectTask.HasOne(prop => prop.Category).WithMany(prop => prop.Tasks).HasForeignKey(prop => prop.CategoryId);
            projectTask.Property(prop => prop.Title).IsRequired().HasMaxLength(100);
            projectTask.Property(prop => prop.Description).HasMaxLength(250).IsRequired(false);
            projectTask.Property(prop => prop.CreationDate);
            projectTask.Property(prop => prop.TaskPriority);
            projectTask.Ignore(prop => prop.Summary);
            projectTask.HasData(projectTasksInit);
        });
    }
}