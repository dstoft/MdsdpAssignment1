using System.Collections.Generic;
using InternalDslTaskManagement.Models;

namespace InternalDslTaskManagement.Services
{
    public class LabelRepository : ILabelRepository
    {
        public LabelRepository()
        {
            Labels = new Dictionary<string, Label>();
        }

        public Dictionary<string, Label> Labels { get; }

        public Label Get(string key)
        {
            return Labels[key];
        }

        public void Upsert(Label model)
        {
            if (Exists(model.GetKey()))
            {
                return;
            }

            Labels.Add(model.GetKey(), model);
        }

        public ICollection<Label> List()
        {
            return Labels.Values;
        }

        public bool Exists(string key)
        {
            return Labels.ContainsKey(key);
        }

        public void Truncate()
        {
            Labels.Clear();
        }

        public void AddTask(Task taskToAdd, Label label)
        {
            Labels[label.GetKey()].Tasks.Add(taskToAdd);
        }
    }
}