using MindQuote.Core.Abstracts;
using MindQuote.Core.Entities;
using MindQuote.Infra.Persistence;

namespace MindQuote.Infra.Repositories;

public class QuoteRepository : IRepository<Quote>
{
    private QuoteContext _context;
    public QuoteRepository(QuoteContext context)
    {
        _context = context;
    }
    public async Task<Guid> CreateAsync(Quote entity)
    {
        _context.Add(entity);
        _context.SaveChanges();
        return entity.Id;
    }

    public async Task<Guid> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Quote>> GetAsync()
    {
        return _context.Quotes;
    }

    public async Task<Quote> GetAsync(Guid id)
    {
        return await _context.Quotes.FindAsync(id);
    }

    public async Task<Quote> GetAsync(Quote entity)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> UpdateAsync(Quote entity)
    {
        throw new NotImplementedException();
    }
}
