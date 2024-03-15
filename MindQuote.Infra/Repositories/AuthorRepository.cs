using MindQuote.Core.Abstracts;
using MindQuote.Core.Entities;
using MindQuote.Infra.FakeData;

namespace MindQuote.Infra.Repositories;

public class AuthorRepository : IRepository<Author>
{
    public async Task<Guid> CreateAsync(Author entity)
    {
        FakeQuotesDB.Authors.Add(entity);
        return entity.Id;
    }

    public async Task<Guid> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Author>> GetAsync()
    {
        return FakeQuotesDB.Authors;
    }

    public async Task<Guid> UpdateAsync(Author entity)
    {
        throw new NotImplementedException();
    }
}