using System;

namespace InternalDslTaskManagement.Models
{
    public class Comment : IEquatable<Comment>
    {
        public Comment(string author, string content, DateTime timestamp)
        {
            Author = author;
            Content = content;
            Timestamp = timestamp;
        }

        public string Author { get; }
        public string Content { get; }
        public DateTime Timestamp { get; }
        public Task Task { get; set; }

        public bool Equals(Comment other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Author == other.Author && Content == other.Content && Equals(Task, other.Task);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Comment) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Author, Content, Task);
        }
    }
}