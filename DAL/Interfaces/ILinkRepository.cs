using DAL.Entities;

namespace DAL.Interfaces
{
    public interface ILinkRepository : IRepository<Link>
    {
        public Task<Link> GetByShortenedUrlAsync(string shortenedUrl);
    }
}
