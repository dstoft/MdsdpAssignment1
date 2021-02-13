using System;
using InternalDslTaskManagement.Builder.Interfaces;
using InternalDslTaskManagement.Models;
using Microsoft.Extensions.DependencyInjection;

namespace InternalDslTaskManagement.Builder
{
    public class CommentBuilder : FromTaskBuilder, ICommentBuilder
    {
        public CommentBuilder(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public string Content { get; private set; }
        public string Author { get; private set; }
        public DateTime? Timestamp { get; private set; }

        public new ICommentBuilder Comment(string name)
        {
            Clear();
            Content = name;
            return this;
        }

        public override void Clear()
        {
            if (Content == null)
            {
                return;
            }

            var newComment = new Comment(Author, Content, Timestamp ?? DateTime.Now);
            ServiceProvider.GetRequiredService<ITaskBuilderService>().AddComment(newComment);

            Content = null;
            Author = null;
            Timestamp = null;
        }

        public ICommentBuilder By(string author)
        {
            Author = author;
            return this;
        }

        public ICommentBuilder PostedAt(string timestamp)
        {
            Timestamp = DateTime.Parse(timestamp);
            return this;
        }

        public new ILabelBuilder Label(string name)
        {
            Clear();
            return base.Label(name);
        }

        public new ITaskBuilder Task(string name)
        {
            Clear();
            return base.Task(name);
        }
    }
}