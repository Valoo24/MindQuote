using MindQuote.Core.Abstracts;

namespace MindQuote.Core.Entities
{
    public class Book : IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string FirstPublicationYear { get; set; }
    }
}