using MyShop.Core.Models;
using System.Linq;

namespace MyShop.DataAccess.InMemory
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        void Commit();
        void Delete(string Id);
        void Insert(T t);
        void Update(T t);
    }
}