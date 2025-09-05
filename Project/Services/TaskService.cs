using TaskTracker.Models;
using TaskTracker.Data;

namespace TaskTracker.Services
{
    public class TaskService
    {
        private readonly TaskRepository _repo;
        private List<TaskItem> _tasks;

        public TaskService()
        {
            _repo = new TaskRepository();
            _tasks = _repo.LoadTasks();
        }

        public void AddTask(string title)
        {
            int newId = _tasks.Any() ? _tasks.Max(t => t.Id) + 1 : 1;
            _tasks.Add(new TaskItem { Id = newId, Title = title, IsCompleted = false });
            _repo.SaveTasks(_tasks);
        }

        public void ListTasks()
        {
            foreach (var task in _tasks)
            {
                Console.WriteLine($"{task.Id}. [{(task.IsCompleted ? "X" : " ")}] {task.Title}");
            }
        }

        public void CompleteTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.IsCompleted = true;
                _repo.SaveTasks(_tasks);
            }
        }

        public void DeleteTask(int id)
        {
            _tasks = _tasks.Where(t => t.Id != id).ToList();
            _repo.SaveTasks(_tasks);
        }
    }
}
