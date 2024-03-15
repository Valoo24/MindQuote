namespace MindQuote.Core.Abstracts;

public interface IRepository<TEntity> where TEntity : IEntity
{
    Task<IEnumerable<TEntity>> GetAsync();
    Task<Guid> CreateAsync(TEntity entity);
    Task<Guid> UpdateAsync(TEntity entity);
    Task<Guid> DeleteAsync(Guid id);
}