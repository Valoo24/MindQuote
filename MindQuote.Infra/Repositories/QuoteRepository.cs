using MindQuote.Core.Abstracts;
using MindQuote.Core.Entities;
using MindQuote.Infra.FakeData;

namespace MindQuote.Infra.Repositories;

public class QuoteRepository : IRepository<Quote>
{
    public async Task<Guid> CreateAsync(Quote entity)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Quote> GetAllAsync()
    {
        foreach(var quote in FakeQuotesDB.Quotes)
        {
            yield return quote;
        }
    }

    public async Task<Quote> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> UpdateAsync(Quote entity)
    {
        throw new NotImplementedException();
    }
}
