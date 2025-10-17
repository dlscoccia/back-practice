using System.Formats.Tar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectef;
using projectef.Models;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<TasksContext>(option => option.UseInMemoryDatabase("TasksDB"));
builder.Services.AddSqlServer<TasksContext>(builder.Configuration.GetConnectionString("cnTasks"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/db", ([FromServices] TasksContext dbContext) =>
{
    dbContext.Database.EnsureCreated();

    return Results.Ok($"In memory DB: {dbContext.Database.IsInMemory()}");
});

app.MapGet("/api/tasks", ([FromServices] TasksContext dbContext) =>
{
    return Results.Ok(dbContext.ProjectTasks.Include(prop => prop.Category));
});

app.MapPost("/api/tasks", async ([FromServices] TasksContext dbContext, [FromBody] ProjectTask projectTask) =>
{

    projectTask.TaskId = Guid.NewGuid();
    projectTask.CreationDate = DateTime.Now;

    await dbContext.AddAsync(projectTask);
    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.MapPut("/api/tasks/{id}", async ([FromServices] TasksContext dbContext, [FromBody] ProjectTask projectTask, [FromRoute] Guid id) =>
{

    var currentTask = dbContext.ProjectTasks.Find(id);

    if (currentTask != null)
    {
        currentTask.CategoryId = projectTask.CategoryId;
        currentTask.Title = projectTask.Title;
        currentTask.Description = projectTask.Description;

        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }

    return Results.NotFound();
});

app.MapDelete("/api/tasks/{id}", async ([FromServices] TasksContext dbContext, [FromRoute] Guid id) =>
{

    var currentTask = dbContext.ProjectTasks.Find(id);

    if (currentTask != null)
    {
        dbContext.Remove(currentTask);
        await dbContext.SaveChangesAsync();
        
        return Results.Ok();
    }

    return Results.NotFound();
});

app.Run();
