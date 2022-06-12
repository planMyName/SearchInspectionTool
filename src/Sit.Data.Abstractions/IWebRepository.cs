namespace Sit.Data;

public interface IWebRepository
{
    public Task<string> GetContentFromAsync(string location);
}