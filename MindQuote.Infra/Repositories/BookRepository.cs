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

    public Task<Guid> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Book>> GetAsync()
    {
        return FakeQuotesDB.Books;
    }

    public async Task<Book> GetAsync(Guid id)
    {
        return FakeQuotesDB.Books.FirstOrDefault(b => b.Id == id) ?? 
            throw new ArgumentNullException($"Book Id {id} is not found");
    }

    public Task<Book> GetAsync(Book entity)
    {
        throw new NotImplementedException();
    }

    public Task<Guid> UpdateAsync(Book entity)
    {
        throw new NotImplementedException();
    }
}