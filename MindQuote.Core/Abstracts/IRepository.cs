namespace MindQuote.Core.Abstracts;

public interface IRepository<TEntity> where TEntity : IEntity
{
    Task<IEnumerable<TEntity>> GetAsync();
    Task<TEntity> GetAsync(Guid id);
    Task<TEntity> GetAsync(TEntity entity);
    Task<Guid> CreateAsync(TEntity entity);
    Task<Guid> UpdateAsync(TEntity entity);
    Task<Guid> DeleteAsync(Guid id);
}