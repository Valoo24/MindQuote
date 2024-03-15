using MindQuote.Core.Abstracts;
using MindQuote.Infra.FakeData;
using MindQuote.Infra.Persistence;

namespace MindQuote.Infra.Repositories;

public class BookAuthorIntermediaryRepository : IRepository<BookAuthorIntermediaryTable>
{
    private QuoteContext _context;
    public BookAuthorIntermediaryRepository(QuoteContext context)
    {
        _context = context;
    }
    public async Task<Guid> CreateAsync(BookAuthorIntermediaryTable entity)
    {
        _context.BookAuthorIntermediaryTable.Add(entity);
        _context.SaveChanges();
        return Guid.Empty;
    }

    public async Task<Guid> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<BookAuthorIntermediaryTable>> GetAsync()
    {
        return _context.BookAuthorIntermediaryTable;
    }

    public async Task<BookAuthorIntermediaryTable> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<BookAuthorIntermediaryTable> GetAsync(BookAuthorIntermediaryTable entity)
    {
        return _context.BookAuthorIntermediaryTable
            .FirstOrDefault(i => i.AuthorId == entity.AuthorId && i.BookId == entity.BookId);
    }

    public async Task<Guid> UpdateAsync(BookAuthorIntermediaryTable entity)
    {
        throw new NotImplementedException();
    }
}
