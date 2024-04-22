using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using shorter.Models;

namespace shorter.Controllers
{
    public class RedirectController : Controller
    {
        private readonly ILogger<RedirectController> _logger;
        private readonly IMapper mapper;

        ILinkService linkService;

        public RedirectController(ILogger<RedirectController> logger, IMapper mapper, ILinkService linkService)
        {
            _logger = logger;
            this.mapper = mapper;
            this.linkService = linkService;
        }
        public async Task<ActionResult> RedirectTo(string shortenedUrl)
        {
            // Поиск длинной ссылки по короткому значению
            
            LinkDTO linkDto = await linkService.GetLinkByShortenedUrl(shortenedUrl);
            LinkViewModel model = mapper.Map<LinkDTO, LinkViewModel>(linkDto);

            // Если длинная ссылка найдена, выполняем редирект
            if (!string.IsNullOrEmpty(model.LongUrl))
            {
                linkDto.ClickCount++;
                await linkService.UpdateLink(linkDto);
                return Redirect(model.LongUrl);
            }

            // Если длинная ссылка не найдена, возвращаем ошибку 404
            return NotFound();
        }
    }
}
