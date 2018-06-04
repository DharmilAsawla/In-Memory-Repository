using System;
using System.Collections.Generic;


namespace Interview
{
    public class Repository<T> : IRepository<T> where T : IStoreable
    {

        private List<T> entities;

        public Repository()
        {
            entities = new List<T>();
        }

        public IEnumerable<T> All()
        {
            return entities;
        }

        public void Delete(IComparable id)
        {
            entities.RemoveAll(WhereIdMatches(id));
        }

        private Predicate<T> WhereIdMatches(IComparable id)
        {
            return i => i.Id.Equals(id);
        }

        public T FindById(IComparable id)
        {
            return entities.Find(WhereIdMatches(id));
        }

        public void Save(T item)
        {
            Delete(item.Id);
            entities.Add(item);
        }
    }
}
