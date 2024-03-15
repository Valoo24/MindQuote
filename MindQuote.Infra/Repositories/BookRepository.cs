using MindQuote.Core.Abstracts;
using MindQuote.Core.Entities;
using MindQuote.Infra.FakeData;

namespace MindQuote.Infra.Repositories;

public class BookRepository : IRepository<Book>
{
    public async Task<Guid> CreateAsync(Book entity)
    {
        FakeQuotesDB.Books.Add(entity);
        return entity.Id;
    }

    public async Task<Guid> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Book>> GetAsync()
    {
        return FakeQuotesDB.Books;
    }

    public async Task<Book> GetAsync(Guid id)
    {
        return FakeQuotesDB.Books.FirstOrDefault(b => b.Id == id);
    }

    public async Task<Book> GetAsync(Book entity)
    {
        return FakeQuotesDB.Books.FirstOrDefault(b => b.Title == entity.Title);
    }

    public async Task<Guid> UpdateAsync(Book entity)
    {
        throw new NotImplementedException();
    }
}