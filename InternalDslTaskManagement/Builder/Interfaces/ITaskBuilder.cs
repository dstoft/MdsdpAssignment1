namespace InternalDslTaskManagement.Builder.Interfaces
{
    public interface ITaskBuilder : IFromTaskBuilder
    {
        public ITaskBuilder Deadline(string deadline);
        public ITaskBuilder Status(string status);
        public ITaskBuilder Assign(string assigned);
    }
}