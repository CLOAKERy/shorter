using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using shorter.Models;
using System.Diagnostics;

namespace shorter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper mapper;

        ILinkService linkService;

        public HomeController(ILogger<HomeController> logger, IMapper mapper, ILinkService linkService)
        {
            _logger = logger;
            this.mapper = mapper;
            this.linkService = linkService;
        }

        public async Task<ActionResult> Index()
        {
            IEnumerable<LinkDTO> linksDtos = await linkService.GetAllLinksAsync();

            LinkViewModels model = new();
            model.linkViewModels = mapper.Map<IEnumerable<LinkDTO>, IEnumerable<LinkViewModel>>(linksDtos);
            model.BaseUrl = $"{Request.Scheme}://{Request.Host}";
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
