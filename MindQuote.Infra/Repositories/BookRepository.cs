using MindQuote.Core.Abstracts;
using MindQuote.Core.Entities;
using MindQuote.Infra.Persistence;

namespace MindQuote.Infra.Repositories;

public class BookRepository : IRepository<Book>
{
    private QuoteContext _context;
    public BookRepository(QuoteContext context)
    {
        _context = context;
    }
    public async Task<Guid> CreateAsync(Book entity)
    {
        _context.Books.Add(entity);
        _context.SaveChanges();
        return entity.Id;
    }

    public async Task<Guid> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Book>> GetAsync()
    {
        return _context.Books;
    }

    public async Task<Book> GetAsync(Guid id)
    {
        return await _context.Books.FindAsync(id);
    }

    public async Task<Book> GetAsync(Book entity)
    {
        return _context.Books
            .FirstOrDefault(b => b.Title == entity.Title);
    }

    public async Task<Guid> UpdateAsync(Book entity)
    {
        throw new NotImplementedException();
    }
}