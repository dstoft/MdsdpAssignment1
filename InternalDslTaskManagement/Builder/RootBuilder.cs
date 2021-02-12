using System;
using InternalDslTaskManagement.Builder.Interfaces;
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
            return _serviceProvider.GetRequiredService<ITaskBuilder>().Task(name);
        }

        public void Clear()
        {
        }
    }
}