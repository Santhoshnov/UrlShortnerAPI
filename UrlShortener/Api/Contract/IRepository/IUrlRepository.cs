using Api.Model;

namespace Api.Contract.IRepository;

public interface IUrlRepository
{
    Url IsUrlExists(string originalUrl);
    Url GetUrlByShortenedUrl(string shortenedUrl);
    void CreateUrl(Url url);
    void Save();
}
