using MindQuote.Core.Entities;

namespace MindQuote.Infra.FakeData;

public static class FakeQuotesDB
{
    public static IList<Quote> Quotes { get; set; } = new List<Quote>
    {
        new Quote
        {
            Id = new("51916512-2c3c-4213-bebf-cb2ece8da098"),
            AuthorId = new("30e23e3f-04d3-4446-a657-ea246ab16f67"),
            Content = "Celui qui est maître de lui-même n'a pas d'autres maîtres."
        },
        new Quote
        {
            Id= new("43f819c6-e662-454e-9916-3bc89402da3c"),
            AuthorId = new("f0fb8f97-c5ca-430c-9aab-f714b7d47eed"),
            Content = "Je suis supérieur aux autres êtres humains, bien plus qu'ils ne sont supérieurs aux singes."
        }
    };

    public static IList<Author> Authors { get; set; } = new List<Author>
    {
        new Author
        {
            Id= new("30e23e3f-04d3-4446-a657-ea246ab16f67"),
            FirstName = "Lao",
            LastName = "Tseu"
        },
        new Author
        {
            Id = new("f0fb8f97-c5ca-430c-9aab-f714b7d47eed"),
            FirstName = "Friedrishe",
            LastName = "Nietzsche"
        }
    };
}