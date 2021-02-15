using System;
using System.Collections.Generic;
using InternalDslTaskManagement.Builder.Interfaces;
using InternalDslTaskManagement.Models;
using InternalDslTaskManagement.Services;
using Microsoft.Extensions.DependencyInjection;

namespace InternalDslTaskManagement.Dsl
{
    public abstract class TaskManagement : ITaskManagement
    {
        private readonly IServiceProvider ServiceProvider;
        protected readonly IRootBuilder TaskManagementSystem;

        public TaskManagement(IServiceProvider serviceProvider, IRootBuilder rootBuilder)
        {
            ServiceProvider = serviceProvider;
            TaskManagementSystem = rootBuilder;
        }

        public abstract void Build();

        public ICollection<Task> ListTasks()
        {
            return ServiceProvider.GetRequiredService<ITaskRepository>().List();
        }

        public Task GetTask(string name)
        {
            return ServiceProvider.GetRequiredService<ITaskRepository>().Get(name);
        }

        public ICollection<Label> ListLabels()
        {
            return ServiceProvider.GetRequiredService<ILabelRepository>().List();
        }

        public Label GetLabel(string name)
        {
            return ServiceProvider.GetRequiredService<ILabelRepository>().Get(name);
        }
    }
}