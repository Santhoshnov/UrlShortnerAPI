using Microsoft.AspNetCore.Mvc;
using Api.Contract.IService;
using Api.Dto;

[ApiController]
public class UrlController : ControllerBase
{
    private readonly IUrlService _urlService;

    public UrlController(IUrlService urlService)
    {
        _urlService = urlService;
    }

    //controller method for posting original url to get the shortened url
    [HttpPost("api/url/shorten")]
    public IActionResult ShortenUrl([FromBody] string originalUrl)
    {
        if (string.IsNullOrEmpty(originalUrl))
        {
            return BadRequest("Original URL is required");
        }

        string shortenedUrl = _urlService.ShortenUrl(originalUrl);
        return Ok(shortenedUrl);
    }

    //controller method for getting original url for the shortened url
    [HttpGet("api/url/{shortened-url}")]
    public IActionResult GetOriginalUrl([FromRoute(Name = "shortened-url")] string shortenedUrl)
    {
        UrlDto urlDto = _urlService.GetOriginalUrl(shortenedUrl);

        if (urlDto == null)
        {
            return NotFound("URL not found");
        }

        return Ok(urlDto);
    }
}
