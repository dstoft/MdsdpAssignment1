using InternalDslTaskManagement.Models;

namespace InternalDslTaskManagement.Services
{
    public interface ITaskRepository : IRepository<string, Task>
    {
    }
}