using DataAccessLibrary;
using DataAccessLibrary.Data;
using DataAccessLibrary.DbAccess;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

// Load appsettings.json
builder.Configuration.AddJsonFile(@"C:\Demos\TaskTrackerCLIApp\TaskTrackerCLI\appsettings.json", optional: false, reloadOnChange: true);

// Register services
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<ITaskData, TaskData>();

var app = builder.Build();

// Resolve  service
var taskService = app.Services.GetRequiredService<ITaskData>();

Console.WriteLine("=== Task Tracker Test Console ===");
bool running = true;

while (running)
{
    Console.WriteLine("\nChoose:");
    Console.WriteLine("1. View Tasks");
    Console.WriteLine("2. Add Task");
    Console.WriteLine("3. Update Task");
    Console.WriteLine("4. Delete Task");
    Console.WriteLine("0. Exit");

    Console.Write("> ");
    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            var tasks = await taskService.GetTasks();
            foreach (var task in tasks)
                Console.WriteLine($"{task.Id}. {(task.IsComplete ? "[x]" : "[ ]")} {task.Title} ({task.CreatedAt:g})");
            break;

        case "2":
            Console.Write("Enter task title: ");
            var title = Console.ReadLine();
            await taskService.InsertTask(new TaskModel { Title = title!, IsComplete = false });
            Console.WriteLine("Task added!");
            break;

        case "3":
            Console.Write("Task ID: ");
            var updateId = int.Parse(Console.ReadLine()!);
            Console.Write("New title: ");
            var newTitle = Console.ReadLine();
            Console.Write("Is complete? (true /false): ");
            var isDone = bool.Parse(Console.ReadLine()!);
            await taskService.UpdateTask(new TaskModel { Id = updateId, Title = newTitle!, IsComplete = isDone });
            Console.WriteLine("Task updated!");
            break;

        case "4":
            Console.Write("Task ID to delete: ");
            var deleteId = int.Parse(Console.ReadLine()!);
            await taskService.DeleteTask(deleteId);
            Console.WriteLine("Task deleted.");
            break;

        case "0":
            running = false;
            break;
    }
}
