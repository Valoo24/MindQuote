namespace MindQuote.Core.Abstracts;

public interface IRepository<TEntity> where TEntity : IEntity
{
    Task<TEntity> GetAsync(Guid id);
    IEnumerable<TEntity> GetAllAsync();
    Task<Guid> CreateAsync(TEntity entity);
    Task<Guid> UpdateAsync(TEntity entity);
    Task<Guid> DeleteAsync(Guid id);
}