using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Application
{
    public interface IUserPost<TEntity,TKey> where TEntity : class where TKey : notnull, IEquatable<TKey>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(TKey id);
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(TKey id);
    }
}
