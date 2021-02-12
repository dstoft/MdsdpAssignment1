using System;
using System.Collections.Generic;

namespace InternalDslTaskManagement.Models
{
    public class Task : IEquatable<Task>
    {
        public Task(string name, string status, DateTime lastStatusUpdateTime, DateTime deadline, string assigned)
        {
            Name = name;
            Status = status;
            LastStatusUpdateTime = lastStatusUpdateTime;
            Deadline = deadline;
            Assigned = assigned;
            Comments = new List<Comment>();
            Labels = new List<Label>();
        }

        public string Name { get; }
        public string Status { get; }
        public DateTime LastStatusUpdateTime { get; }
        public DateTime Deadline { get; }
        public string Assigned { get; }
        public List<Comment> Comments { get; }
        public List<Label> Labels { get; }

        public bool Equals(Task other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Task) obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }

        public override string ToString()
        {
            return "Task: " + Name + ";" + Deadline + ";" + Status + ";" + Assigned + ";" + Labels.Count + ";" +
                   Comments.Count;
        }
    }
}