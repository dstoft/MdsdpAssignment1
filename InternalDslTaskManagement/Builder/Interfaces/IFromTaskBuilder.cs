namespace InternalDslTaskManagement.Builder.Interfaces
{
    public interface IFromTaskBuilder : IRootBuilder
    {
        public ILabelBuilder Label(string name);
        public ICommentBuilder Comment(string name);
    }
}