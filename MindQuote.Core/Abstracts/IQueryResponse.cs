namespace MindQuote.Core.Abstracts
{
    public interface IQueryResponse<TObject>
    {
        TObject Content { get; set; }
    }
}