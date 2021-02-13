namespace InternalDslTaskManagement.Models
{
    public interface IUnique<TKey>
    {
        public TKey GetKey();
    }
}