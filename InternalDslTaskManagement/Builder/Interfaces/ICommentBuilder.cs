namespace InternalDslTaskManagement.Builder.Interfaces
{
    public interface ICommentBuilder : IFromTaskBuilder
    {
        public ICommentBuilder By(string author);
        public ICommentBuilder PostedAt(string timestamp);
    }
}