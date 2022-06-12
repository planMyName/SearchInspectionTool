namespace Sit.Data;

public interface IWebRepository
{
    public Task<string> GetContentFrom(string location);
}