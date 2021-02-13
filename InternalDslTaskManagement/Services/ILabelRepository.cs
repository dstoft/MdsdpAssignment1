using InternalDslTaskManagement.Models;

namespace InternalDslTaskManagement.Services
{
    public interface ILabelRepository : IRepository<string, Label>
    {
        public void AddTask(Task taskToAdd, Label label);
    }
}