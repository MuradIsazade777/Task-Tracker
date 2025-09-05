using System.Text.Json;
using TaskTracker.Models;

namespace TaskTracker.Data
{
    public class TaskRepository
    {
        private const string FilePath = "tasks.json";

        public List<TaskItem> LoadTasks()
        {
            if (!File.Exists(FilePath)) return new List<TaskItem>();
            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
        }

        public void SaveTasks(List<TaskItem> tasks)
        {
            var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }
    }
}
