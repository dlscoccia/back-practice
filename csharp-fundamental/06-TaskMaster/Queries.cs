using BetterConsoles.Tables;
using BetterConsoles.Tables.Configuration;
namespace TaskMaster
{
  public class Queries(List<Task> _tasks)
  {
    private List<Task> Tasks = _tasks;

    public void ListTasks()
    {
      ForegroundColor = ConsoleColor.DarkBlue;
      WriteLine("----Lista de tareas----");
      Table table = new Table("Id", "Descripcion", "Estado");
      foreach (var task in Tasks)
      {
        table.AddRow(task.Id, task.Description, task.Completed ? "Completada" : "");

      }
      table.Config = TableConfig.Unicode();
      Write(table.ToString());
      ReadKey();

    }

    public List<Task> AddTask()
    {
      try
      {
        ResetColor();
        Clear();

        WriteLine("---Añadir tarea---");
        WriteLine("Ingrese la descripcion de la tarea");
        var description = ReadLine()!;

        Task newTask = new Task(Utils.GenerateId(), description);
        Tasks.Add(newTask);
        ForegroundColor = ConsoleColor.DarkGreen;
        WriteLine("Tarea añadida con exito");

        ResetColor();

        return Tasks;
      }
      catch (Exception ex)
      {
        ForegroundColor = ConsoleColor.Red;
        WriteLine(ex.Message);
        return Tasks;
      }
    }

    public List<Task> MarkAsCompleted()
    {
      try
      {
        ResetColor();
        Clear();

        WriteLine("---Marcar tarea como completada---");
        Write("Ingrese el id de la tarea: ");
        var id = ReadLine()!;

        Task task = Tasks.Find(t => t.Id == id)!;

        if (task == null)
        {
          ForegroundColor = ConsoleColor.Red;
          WriteLine($"No se encontro la tarea con el id {id}");
          return Tasks;
        }

        task.Completed = true;
        task.ModifiedAt = DateTime.Now;
        ForegroundColor = ConsoleColor.DarkGreen;
        WriteLine("Tarea completada con exito");

        ResetColor();

        return Tasks;
      }
      catch (Exception ex)
      {
        ForegroundColor = ConsoleColor.Red;
        WriteLine(ex.Message);
        return Tasks;
      }
    }
    public List<Task> EditTask()
    {
      try
      {
        ResetColor();
        Clear();

        WriteLine("---Editar tarea---");
        Write("Ingrese el id de la tarea: ");
        var id = ReadLine()!;

        Task task = Tasks.Find(t => t.Id == id)!;

        if (task == null)
        {
          ForegroundColor = ConsoleColor.Red;
          WriteLine($"No se encontro la tarea con el id {id}");
          return Tasks;
        }

        WriteLine("Ingrese la descripcion de la tarea");
        var description = ReadLine()!;

        task.Description = description;
        task.ModifiedAt = DateTime.Now;
        ForegroundColor = ConsoleColor.DarkGreen;
        WriteLine("Tarea editada con exito");

        ResetColor();

        return Tasks;
      }
      catch (Exception ex)
      {
        ForegroundColor = ConsoleColor.Red;
        WriteLine(ex.Message);
        return Tasks;
      }
    }

    public List<Task> RemoveTask()
    {
      try
      {
        ResetColor();
        Clear();

        WriteLine("---Eliminar tarea---");
        Write("Ingrese el id de la tarea: ");
        var id = ReadLine()!;

        Task task = Tasks.Find(t => t.Id == id)!;

        if (task == null)
        {
          ForegroundColor = ConsoleColor.Red;
          WriteLine($"No se encontro la tarea con el id {id}");
          return Tasks;
        }

        Tasks.Remove(task);
        ForegroundColor = ConsoleColor.DarkGreen;
        WriteLine("Tarea elimanada con exito");

        ResetColor();

        return Tasks;
      }
      catch (Exception ex)
      {
        ForegroundColor = ConsoleColor.Red;
        WriteLine(ex.Message);
        return Tasks;
      }
    }

    public void TasksByState()
    {
      Clear();

      try
      {
        ResetColor();
        WriteLine("----Tareas por estado----");
        WriteLine("1. Completadas");
        WriteLine("2. Pendientes");
        Write("Ingrese la opcion de las tareas a mostrar: ");
        string taskState = ReadLine()!;

        if (taskState != "1" && taskState != "2")
        {
          ForegroundColor = ConsoleColor.Red;
          WriteLine("Opcion invalida");
          ResetColor();
          return;
        }

        bool completed = taskState == "1";

        List<Task> filteredTasks = Tasks.Where(t => t.Completed == completed).ToList();

        if (filteredTasks.Count == 0)
        {
          ForegroundColor = ConsoleColor.Red;
          WriteLine("No se encontraron tareas con el estado solicitado");
          ResetColor();
          return;
        }
        ForegroundColor = completed ? ConsoleColor.DarkGreen : ConsoleColor.DarkRed;
        Table table = new Table("Id", "Descripcion", "Estado");
        foreach (var task in filteredTasks)
        {
          table.AddRow(task.Id, task.Description, task.Completed ? "Completada" : "");

        }
        table.Config = TableConfig.Unicode();
        Write(table.ToString());
        ReadKey();
        ResetColor();
        Clear();
      }
      catch (Exception ex)
      {
        ForegroundColor = ConsoleColor.Red;
        WriteLine(ex.Message);
      }
    }
    public void TasksByDescription()
    {
      Clear();

      try
      {
        ResetColor();
        WriteLine("----Tareas por descripcion----");
        WriteLine("Ingrese la descripcion de la tarea");
        var description = ReadLine()!;

        List<Task> matchingTasks = Tasks.FindAll(t => t.Description?.Contains(description, StringComparison.OrdinalIgnoreCase) ?? false).ToList();

        if (matchingTasks.Count == 0)
        {
          ForegroundColor = ConsoleColor.Red;
          WriteLine("No se encontraron tareas con la descripcion solicitada");
          ResetColor();
          return;
        }
        ForegroundColor = ConsoleColor.DarkGreen;
        Table table = new Table("Id", "Descripcion", "Estado");
        foreach (var task in matchingTasks)
        {
          table.AddRow(task.Id, task.Description, task.Completed ? "Completada" : "");

        }
        table.Config = TableConfig.Unicode();
        Write(table.ToString());
        ReadKey();
        ResetColor();
        Clear();
      }
      catch (Exception ex)
      {
        ForegroundColor = ConsoleColor.Red;
        WriteLine(ex.Message);
      }
    }


  }
}
