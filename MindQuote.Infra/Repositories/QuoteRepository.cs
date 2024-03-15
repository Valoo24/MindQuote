using MindQuote.Core.Abstracts;
using MindQuote.Core.Entities;
using MindQuote.Infra.FakeData;

namespace MindQuote.Infra.Repositories;

public class QuoteRepository : IRepository<Quote>
{
    public async Task<Guid> CreateAsync(Quote entity)
    {
        FakeQuotesDB.Quotes.Add(entity);
        return entity.Id;
    }

    public async Task<Guid> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Quote>> GetAsync()
    {
        return FakeQuotesDB.Quotes;
    }

    public async Task<Quote> GetAsync(Guid id)
    {
        return FakeQuotesDB.Quotes.FirstOrDefault(q => q.Id == id);
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
