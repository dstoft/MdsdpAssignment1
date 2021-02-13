using System.Collections.Generic;

namespace InternalDslTaskManagement.Services
{
    public interface IRepository<TKey, TModel>
    {
        public TModel Get(TKey key);
        public void Upsert(TModel model);
        public ICollection<TModel> List();
        public bool Exists(TKey key);
    }
}