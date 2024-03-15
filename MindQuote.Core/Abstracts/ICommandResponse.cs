namespace MindQuote.Core.Abstracts;

public interface ICommandResponse<TObject>
{
    TObject Content { get; set; }
}