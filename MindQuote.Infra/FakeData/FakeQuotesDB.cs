using MindQuote.Core.Entities;

namespace MindQuote.Infra.FakeData;

public static class FakeQuotesDB
{
    public static IList<Quote> Quotes { get; set; } = new List<Quote>
    {
        new Quote
        {
            Id = Guid.NewGuid(),
            Content = "Celui qui est maître de lui-même n'a pas d'autres maîtres.",
            AuthorFirstName = "Lao",
            AuthorLastName = "Tseu",
            Origin = null
        },
        new Quote
        {
            Id= Guid.NewGuid(),
            Content = "Je suis supérieur aux autres êtres humains, bien plus qu'ils ne sont supérieurs aux singes.",
            AuthorFirstName = "Friedrische",
            AuthorLastName = "Nietzsche",
            Origin = "Ainsi parlait Zarathoustra"
        }
    };
}