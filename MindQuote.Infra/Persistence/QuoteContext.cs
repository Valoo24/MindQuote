using Microsoft.EntityFrameworkCore;
using MindQuote.Core.Entities;
using MindQuote.Infra.FakeData;

namespace MindQuote.Infra.Persistence
{
    public class QuoteContext : DbContext
    {
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthorIntermediaryTable> BookAuthorIntermediaryTable { get; set; }

        public QuoteContext(DbContextOptions<QuoteContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quote>(quote =>
            {
                quote.HasIndex(q => q.Id);
            });
            modelBuilder.Entity<Author>(author =>
            {
                author.HasIndex(a => a.Id);
            });
            modelBuilder.Entity<Book>(book =>
            {
                book.HasIndex(b => b.Id);
            });
            modelBuilder.Entity<BookAuthorIntermediaryTable>().HasKey(ba => new { ba.BookId, ba.AuthorId });
        }
    }
}