using System;
using InternalDslTaskManagement.Builder.Interfaces;
using InternalDslTaskManagement.Services;
using Microsoft.Extensions.DependencyInjection;

namespace InternalDslTaskManagement.Builder
{
    public class RootBuilder : IRootBuilder
    {
        private readonly IServiceProvider _serviceProvider;

        public RootBuilder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ITaskBuilder Task(string name)
        {
            _serviceProvider.GetRequiredService<ITaskRepository>().Truncate();
            _serviceProvider.GetRequiredService<ILabelRepository>().Truncate();
            return _serviceProvider.GetRequiredService<ITaskBuilder>().Task(name);
        }

        public void Clear()
        {
        }
    }
}