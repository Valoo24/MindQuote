using MindQuote.Core.Abstracts;
using MindQuote.Core.Entities;
using MindQuote.Infra.Persistence;

namespace MindQuote.Infra.Repositories;

public class AuthorRepository : IRepository<Author>
{
    private QuoteContext _context;
    public AuthorRepository(QuoteContext context)
    {
        _context = context;
    }
    public async Task<Guid> CreateAsync(Author entity)
    {
        _context.Authors.Add(entity);
        _context.SaveChanges();
        return entity.Id;
    }

    public async Task<Guid> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Author>> GetAsync()
    {
        return _context.Authors;
    }

    public async Task<Author> GetAsync(Guid id)
    {
        return await _context.Authors.FindAsync(id);
    }

    public async Task<Author> GetAsync(Author entity)
    {
        return _context.Authors
            .FirstOrDefault(a => a.FirstName == entity.FirstName && a.LastName == entity.LastName);
    }

    public async Task<Guid> UpdateAsync(Author entity)
    {
        throw new NotImplementedException();
    }
}