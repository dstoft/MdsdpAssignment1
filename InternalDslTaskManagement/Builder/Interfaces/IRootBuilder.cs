namespace InternalDslTaskManagement.Builder.Interfaces
{
    public interface IRootBuilder
    {
        public ITaskBuilder Task(string name);
        public void Clear();
    }
}