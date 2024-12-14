using Api.Contract.IRepository;
using Api.Model;

namespace Api.Repository;

public class UrlRepository : IUrlRepository
{
    private readonly ApplicationDbContext _context;

    public UrlRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    //check if original url already exists in database
    public Url IsUrlExists(string originalUrl)
    {
        return _context.Url.FirstOrDefault(o => o.OriginalUrl == originalUrl);
    }

    //Query the db to get the url for the provided shortened url
    public Url GetUrlByShortenedUrl(string shortenedUrl)
    {
        return _context.Url.FirstOrDefault(u => u.ShortenedUrl == shortenedUrl);
    }

    //stores the mapped url object to the inmemory(ie:dbcontext)
    public void CreateUrl(Url url)
    {
        _context.Url.Add(url);
    }

    //After url object is added to the context saves the context to the database
    public void Save()
    {
        _context.SaveChanges();
    }
}
