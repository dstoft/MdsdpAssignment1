using System;
using InternalDslTaskManagement.Builder.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace InternalDslTaskManagement.Builder
{
    public abstract class FromTaskBuilder : IFromTaskBuilder
    {
        protected readonly IServiceProvider ServiceProvider;

        protected FromTaskBuilder(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public ILabelBuilder Label(string name)
        {
            return ServiceProvider.GetRequiredService<ILabelBuilder>().Label(name);
        }

        public ICommentBuilder Comment(string name)
        {
            return ServiceProvider.GetRequiredService<ICommentBuilder>().Comment(name);
        }

        public ITaskBuilder Task(string name)
        {
            return ServiceProvider.GetRequiredService<ITaskBuilder>().Task(name);
        }

        public void Build()
        {
            ServiceProvider.GetRequiredService<ITaskBuilder>().Clear();
            ServiceProvider.GetRequiredService<ILabelBuilder>().Clear();
            ServiceProvider.GetRequiredService<ICommentBuilder>().Clear();
        }

        public abstract void Clear();
    }
}