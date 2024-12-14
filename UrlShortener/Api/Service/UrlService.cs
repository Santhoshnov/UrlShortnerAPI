using Api.Contract.IService;
using Api.Contract.IRepository;
using Api.Model;
using Api.Dto;


namespace Api.Service;

public class UrlService : IUrlService
{
    private readonly IUrlRepository _urlRepository;

    public UrlService(IUrlRepository urlRepository)
    {
        _urlRepository = urlRepository;
    }


    //service method for posting original url to get the shortened url
    public string ShortenUrl(string originalUrl)
    {
        Url existingUrl = _urlRepository.IsUrlExists(originalUrl);

        if (existingUrl != null)
        {
            return existingUrl.ShortenedUrl;
        }
        
        string shortenedUrl = GenerateShortenedUrl();
        Url url = new Url
        {
            Id = Guid.NewGuid(),
            OriginalUrl = originalUrl,
            ShortenedUrl = shortenedUrl
        };

        _urlRepository.CreateUrl(url);
        _urlRepository.Save();

        return shortenedUrl;
    }

    //service method for getting original url for the shortened url
    public UrlDto GetOriginalUrl(string shortenedUrl)
    {
        Url url = _urlRepository.GetUrlByShortenedUrl(shortenedUrl);
        if (url == null)
        {
            return null;
        }

        return new UrlDto
        {
            OriginalUrl = url.OriginalUrl,
            ShortenedUrl = url.ShortenedUrl
        };
    }

    //helper method for generate short url for the given original url
    private string GenerateShortenedUrl()
    {
        return Guid.NewGuid().ToString().Substring(0, 8);  
    }
}
