using AnimalRepair.BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Interfaces;
using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using DAL.Repositories;


namespace BLL.Services
{
    public class LinkService : ILinkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LinkService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddLink(LinkDTO linkDto)
        {
            if (string.IsNullOrEmpty(linkDto.LongUrl))
                throw new ValidationException("Длинный URL не может быть пустым", "");

            var link = _mapper.Map<LinkDTO, Link>(linkDto);
            await _unitOfWork.Links.CreateAsync(link);
        }

        public async Task UpdateLink(LinkDTO linkDto)
        {
            Link updatedLink = _mapper.Map<LinkDTO, Link>(linkDto);
            await _unitOfWork.Links.UpdateAsync(updatedLink);
        }

        public async Task RemoveLink(int linkId)
        {
            Link link = await _unitOfWork.Links.GetAsync(linkId);
            if (link == null)
                throw new ValidationException("Ссылка не найдена", "");

            await _unitOfWork.Links.DeleteAsync(linkId);
        }

        public async Task<LinkDTO> GetLinkById(int linkId)
        {
            Link link = await _unitOfWork.Links.GetAsync(linkId);
            if (link == null)
                throw new ValidationException("Ссылка не найдена", "");

            LinkDTO linkDto = _mapper.Map<Link, LinkDTO>(link);
            return linkDto;
        }

        public async Task<IEnumerable<LinkDTO>> GetAllLinksAsync()
        {
            IEnumerable<Link> links = await _unitOfWork.Links.GetAllAsync();
            return _mapper.Map<IEnumerable<Link>, IEnumerable<LinkDTO>>(links);
        }
        public async Task<LinkDTO> GetLinkByShortenedUrl(string shortenedUrl)
        {
            Link link = await _unitOfWork.Links.GetByShortenedUrlAsync(shortenedUrl);
            if (link == null)
                throw new ValidationException("Ссылка не найдена", "");

            LinkDTO linkDto = _mapper.Map<Link, LinkDTO>(link);
            return linkDto;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
