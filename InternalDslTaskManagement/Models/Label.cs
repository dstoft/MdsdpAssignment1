using System;
using System.Collections.Generic;

namespace InternalDslTaskManagement.Models
{
    public class Label : IEquatable<Label>, IUnique<string>
    {
        public Label(string name)
        {
            Name = name;
            Tasks = new List<Task>();
        }

        public string Name { get; }
        public List<Task> Tasks { get; }

        public bool Equals(Label other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name;
        }

        public string GetKey()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Label) obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }

        public override string ToString()
        {
            return "Label: " + Name + ";" + Tasks.Count;
        }
    }
}