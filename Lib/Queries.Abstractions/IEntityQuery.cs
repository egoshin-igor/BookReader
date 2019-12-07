using System.Linq;

namespace MusicStore.Lib.Queries.Abstractions
{
    public interface IEntityQuery<TEntity> : IQueryable<TEntity> where TEntity : class
    {
    }
}
