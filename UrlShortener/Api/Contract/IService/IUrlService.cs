using Api.Dto;

namespace Api.Contract.IService;
public interface IUrlService
{
    string ShortenUrl(string originalUrl);
    UrlDto GetOriginalUrl(string shortenedUrl);
}
