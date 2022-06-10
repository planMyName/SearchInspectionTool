namespace Sit.Data.Abstractions
{
    public interface IWebRepository
    {
        public Task<string> GetContentFrom(string location);
    }
}