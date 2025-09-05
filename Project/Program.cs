using TaskTracker.Services;

public partial class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var service = new TaskService();

        while (true)
        {
            Console.WriteLine("\n1. Add Task\n2. List Tasks\n3. Complete Task\n4. Delete Task\n5. Exit");
            Console.Write("Choose: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter task title: ");
                    string? input = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(input))
                    {
                        service.AddTask(input);
                    }
                    else
                    {
                        Console.WriteLine("Task title cannot be empty.");
                    }
                    break;

                case "2":
                    service.ListTasks();
                    break;

                case "3":
                    Console.Write("Enter task ID to complete: ");
                    int completeId = int.Parse(Console.ReadLine() ?? "0");
                    service.CompleteTask(completeId);
                    break;

                case "4":
                    Console.Write("Enter task ID to delete: ");
                    int deleteId = int.Parse(Console.ReadLine() ?? "0");
                    service.DeleteTask(deleteId);
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}