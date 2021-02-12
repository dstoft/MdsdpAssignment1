using InternalDslTaskManagement.Models;

namespace InternalDslTaskManagement.Builder.Interfaces
{
    public interface ITaskBuilderService
    {
        public void AddLabel(Label label);
        public void AddComment(Comment comment);
    }
}