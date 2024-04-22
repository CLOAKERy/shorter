using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ILinkService : IDisposable
    {
        Task AddLink(LinkDTO linkDto);
        Task UpdateLink(LinkDTO linkDto);
        Task RemoveLink(int linkId);
        Task<LinkDTO> GetLinkById(int linkId);
        Task<IEnumerable<LinkDTO>> GetAllLinksAsync();
        Task<LinkDTO> GetLinkByShortenedUrl(string shortenedUrl);
    }
}
