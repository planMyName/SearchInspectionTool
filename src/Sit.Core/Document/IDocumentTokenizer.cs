namespace Sit.Core.Document;

public interface IDocumentTokenizer
{
    ICollection<DocumentToken> TokenizeHyperlinks(string result);
}