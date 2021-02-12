using System;

namespace InternalDslTaskManagement.Models
{
    public class TaskLabel : IEquatable<TaskLabel>
    {
        public TaskLabel(Task task, Label label)
        {
            Task = task;
            Label = label;
        }

        public Task Task { get; }
        public Label Label { get; }

        public bool Equals(TaskLabel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Task, other.Task) && Equals(Label, other.Label);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TaskLabel) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Task, Label);
        }
    }
}