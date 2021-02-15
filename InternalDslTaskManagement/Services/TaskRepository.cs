using System.Collections.Generic;
using InternalDslTaskManagement.Models;

namespace InternalDslTaskManagement.Services
{
    public class TaskRepository : ITaskRepository
    {
        public TaskRepository()
        {
            Tasks = new Dictionary<string, Task>();
        }

        public Dictionary<string, Task> Tasks { get; }


        public Task Get(string key)
        {
            return Tasks[key];
        }

        public void Upsert(Task model)
        {
            if (Exists(model.GetKey()))
            {
                var task = Get(model.GetKey());
                task.Assigned = model.Assigned ?? task.Assigned;
                task.Status = model.Status ?? task.Status;
                task.LastStatusUpdateTime = model.LastStatusUpdateTime;
                task.Deadline = model.Deadline;
                task.Comments = model.Comments;
                task.Labels = model.Labels;
            }
            else
            {
                Tasks.Add(model.GetKey(), model);
            }
        }

        public ICollection<Task> List()
        {
            return Tasks.Values;
        }

        public bool Exists(string key)
        {
            return Tasks.ContainsKey(key);
        }

        public void Truncate()
        {
            Tasks.Clear();
        }
    }
}