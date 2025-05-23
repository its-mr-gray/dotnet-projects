using TaskTracker.Cli.Models;
using System.Text.Json;


class Program {
    static void Main(string[] args)
    {
        string[] menuOptions = ["1. add task", "2. list tasks", "3. remove task"];
        List<TaskItem> taskItems = [];
        string jsonFilePath = "tasks.json";

        CreateJsonIfNotExists(jsonFilePath);
        taskItems = LoadTasks(jsonFilePath);

        bool running = true;

        while (running)
        {
            foreach (var option in menuOptions)
            {
                Console.WriteLine(option);
            }

            Console.Write("which action would you like to perform?");
            string? input = Console.ReadLine();

            if (input == "1")
            {
                AddTask(taskList: taskItems);
            }
            else if (input == "2")
            {
                ListTasks(taskList: taskItems);
            }
            else if (input == "3")
            {
                RemoveTask(taskList: taskItems);
            }
            else
            {
                Console.WriteLine("Invalid option, try again \n");
                break;
            }
            SaveTasks(taskItems, jsonFilePath);
            break;
        }

        static void AddTask(List<TaskItem> taskList)
        {
            /* adds a task. a task needs:
            an id,
            description (required),
            status (required),
            createdat,
            updatedat
            */


        }

        static void ListTasks(List<TaskItem> taskList)
        {
            // lists tasks
        }

        static void RemoveTask(List<TaskItem> taskList)
        {
            // removes a task
        }

        static void CreateJsonIfNotExists(string filepath)
        {
            if (!File.Exists(filepath))
            {
                var defaultData = new List<TaskItem>();
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(defaultData, options);
                File.WriteAllText(filepath, jsonString); // creates the file and writes to it!
            }
        }

        static List<TaskItem> LoadTasks(string filepath)
        {
            string jsonData = File.ReadAllText(filepath);
            if (string.IsNullOrWhiteSpace(jsonData))
            {
                return [];
            }
            var tasks = JsonSerializer.Deserialize<List<TaskItem>>(jsonData);
            return tasks ?? []; // ?? checks if the value on the left is a null value and uses the value on the right as a default if so
        }
        
        static void SaveTasks (List<TaskItem> taskList, string filepath)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(taskList, options);
            File.WriteAllText(filepath, jsonString); 
        }
    }
}