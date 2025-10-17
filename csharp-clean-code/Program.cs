
List<string> TaskList = new List<string>();

int menuOption = 0;
do
{
    menuOption = ShowMainMenu();

    switch (menuOption)
    {
        case 1:
            ShowMenuAdd();
            break;
        case 2:
            showMenuRemove();
            break;
        case 3:
            ShowMenuTaskList();
            break;
    }
} while ((Menu)menuOption != Menu.Exit);


int ShowMainMenu()
{
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Ingrese la opción a realizar: ");
    Console.WriteLine("1. Nueva tarea");
    Console.WriteLine("2. Remover tarea");
    Console.WriteLine("3. Tareas pendientes");
    Console.WriteLine("4. Salir");

    string optionSelected = Console.ReadLine();
    return Convert.ToInt32(optionSelected);
}

void showMenuRemove()
{
    try
    {
        Console.WriteLine("Ingrese el número de la tarea a remover: ");
        ShowTaskList();

        string optionSelected = Console.ReadLine();
        int indexToRemove = Convert.ToInt32(optionSelected) - 1;

        if (indexToRemove > TaskList.Count - 1 || indexToRemove < 0)
        {
            Console.WriteLine("Número de tarea no es valido");
        }
        else
        {


            if (TaskList.Count > 0 && indexToRemove > -1)
            {
                string taskToRemove = TaskList[indexToRemove];
                TaskList.RemoveAt(indexToRemove);
                Console.WriteLine($"Tarea {taskToRemove} eliminada");
            }
        }

    }
    catch (Exception)
    {
        Console.WriteLine("Ha ocurrido un error eliminando la tarea");
    }
}

void ShowMenuAdd()
{
    try
    {
        Console.WriteLine("Ingrese el nombre de la tarea: ");
        string taskToAdd = Console.ReadLine();
        TaskList.Add(taskToAdd);
        Console.WriteLine("Tarea registrada");
    }
    catch (Exception)
    {
    }
}

void ShowMenuTaskList()
{
    if (TaskList?.Count > 0)
    {
        ShowTaskList();
    }
    else
    {
        Console.WriteLine("No hay tareas por realizar");
    }
}

void ShowTaskList()
{
    Console.WriteLine("----------------------------------------");
    int indexTask = 1;
    TaskList.ForEach(task => Console.WriteLine($"{indexTask++}. {task}"));
    Console.WriteLine("----------------------------------------");
}


public enum Menu
{
    Add = 1,
    Remove = 2,
    List = 3,
    Exit = 4
}

