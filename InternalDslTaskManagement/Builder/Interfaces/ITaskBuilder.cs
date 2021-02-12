using System;

namespace InternalDslTaskManagement.Builder.Interfaces
{
    public interface ITaskBuilder : IFromTaskBuilder
    {
        public ITaskBuilder Deadline(DateTime deadline);
        public ITaskBuilder Status(string status);
        public ITaskBuilder Assign(string assigned);
    }
}