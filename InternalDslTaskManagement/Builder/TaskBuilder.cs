using System;
using System.Collections.Generic;
using InternalDslTaskManagement.Builder.Interfaces;
using InternalDslTaskManagement.Models;
using InternalDslTaskManagement.Services;
using Microsoft.Extensions.DependencyInjection;

namespace InternalDslTaskManagement.Builder
{
    public class TaskBuilder : FromTaskBuilder, ITaskBuilder, ITaskBuilderService
    {
        public TaskBuilder(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public string TaskName { get; private set; }
        public DateTime? TaskDeadline { get; private set; }
        public string TaskStatus { get; private set; }
        public string TaskAssigned { get; private set; }
        public List<Label> Labels { get; private set; }
        public List<Comment> Comments { get; private set; }

        public ITaskBuilder Deadline(string deadline)
        {
            TaskDeadline = DateTime.Parse(deadline);
            return this;
        }

        public ITaskBuilder Status(string status)
        {
            TaskStatus = status;
            return this;
        }

        public ITaskBuilder Assign(string assigned)
        {
            TaskAssigned = assigned;
            return this;
        }

        public override void Clear()
        {
            if (TaskName == null)
            {
                Labels = new List<Label>();
                Comments = new List<Comment>();
                return;
            }

            var task = new Task(TaskName, TaskStatus, DateTime.Now, TaskDeadline ?? DateTime.MaxValue, TaskAssigned);
            task.Labels.AddRange(Labels);
            task.Comments.AddRange(Comments);
            ServiceProvider.GetRequiredService<ITaskRepository>().Upsert(task);
            task = ServiceProvider.GetRequiredService<ITaskRepository>().Get(task.Name);
            var labelRepository = ServiceProvider.GetRequiredService<ILabelRepository>();
            Labels.ForEach(label => labelRepository.AddTask(task, label));

            TaskName = null;
            TaskDeadline = null;
            TaskStatus = null;
            TaskAssigned = null;
            Labels = new List<Label>();
            Comments = new List<Comment>();
        }

        public new ITaskBuilder Task(string name)
        {
            Clear();
            TaskName = name;
            return this;
        }

        public void AddLabel(Label label)
        {
            Labels.Add(label);
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }
    }
}