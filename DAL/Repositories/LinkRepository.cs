using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class LinkRepository : BaseRepository<Link>, ILinkRepository
    {
        public LinkRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Link> GetByShortenedUrlAsync(string shortenedUrl)
        {
            return await _dbContext.Set<Link>()
                .AsNoTracking()
                .FirstOrDefaultAsync(link => link.ShortenedUrl == shortenedUrl);
        }
    }
}
