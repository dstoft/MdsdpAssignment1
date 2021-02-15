using System.Collections.Generic;
using InternalDslTaskManagement.Models;

namespace InternalDslTaskManagement.Dsl
{
    public interface ITaskManagement
    {
        public abstract void Build();
        public ICollection<Task> ListTasks();
        public Task GetTask(string name);
        public ICollection<Label> ListLabels();
        public Label GetLabel(string name);
    }
}