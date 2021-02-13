using System;
using System.Collections.Generic;
using InternalDslTaskManagement.Builder.Interfaces;
using InternalDslTaskManagement.Models;
using InternalDslTaskManagement.Services;
using Microsoft.Extensions.DependencyInjection;

namespace InternalDslTaskManagement.Dsl
{
    public abstract class TaskManagement
    {
        private readonly IServiceProvider ServiceProvider;
        protected readonly IRootBuilder TaskManagementSystem;

        public TaskManagement(IServiceProvider serviceProvider, IRootBuilder rootBuilder)
        {
            ServiceProvider = serviceProvider;
            TaskManagementSystem = rootBuilder;
        }

        public abstract void Build();

        public ICollection<Task> GetTasks()
        {
            return ServiceProvider.GetRequiredService<ITaskRepository>().List();
        }

        public ICollection<Label> GetLabels()
        {
            return ServiceProvider.GetRequiredService<ILabelRepository>().List();
        }
    }
}