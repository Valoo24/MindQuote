using MindQuote.Core.Abstracts;
using MindQuote.Infra.FakeData;

namespace MindQuote.Infra.Repositories;

public class BookAuthorIntermediaryRepository : IRepository<BookAuthorIntermediaryTable>
{
    public async Task<Guid> CreateAsync(BookAuthorIntermediaryTable entity)
    {
        FakeQuotesDB.BookAuthorIntermediaryTable.Add(entity);
        return Guid.Empty;
    }

    public async Task<Guid> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<BookAuthorIntermediaryTable>> GetAsync()
    {
        return FakeQuotesDB.BookAuthorIntermediaryTable;
    }

    public async Task<BookAuthorIntermediaryTable> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<BookAuthorIntermediaryTable> GetAsync(BookAuthorIntermediaryTable entity)
    {
        return FakeQuotesDB.BookAuthorIntermediaryTable
            .FirstOrDefault(i => i.AuthorId == entity.AuthorId && i.BookId == entity.BookId);
    }

    public async Task<Guid> UpdateAsync(BookAuthorIntermediaryTable entity)
    {
        throw new NotImplementedException();
    }
}
