using AutoMapper;
using BLL.BusinessModel;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using shorter.Models;

namespace shorter.Controllers;

public class CrudController : Controller
{
    private readonly ILogger<CrudController> _logger;
    private readonly IMapper mapper;

    ILinkService linkService;

    public CrudController(ILogger<CrudController> logger, IMapper mapper, ILinkService linkService)
    {
        _logger = logger;
        this.mapper = mapper;
        this.linkService = linkService;
    }
    public IActionResult IndexCreate()
    {
        return View();
    }

    public async Task<ActionResult> Create(LinkViewModel model)
    {
        model.ClickCount = 0;
        model.CreatedDate = DateTime.Now;
        model.ShortenedUrl = ShortLinkGenerator.GenerateShortLink();
        LinkDTO linkDto = mapper.Map<LinkViewModel, LinkDTO>(model);
        await linkService.AddLink(linkDto);
        return RedirectToAction("Index", "Home");
    }

    public async Task<ActionResult> Edit(int id)
    {
        var linkDto = await linkService.GetLinkById(id);
        var linkViewModel = mapper.Map<LinkDTO, LinkViewModel>(linkDto);
        return View(linkViewModel);
    }
    [HttpPost]
    public async Task<ActionResult> Edit(LinkViewModel model)
    {
        if (ModelState.IsValid)
        {
            var linkDto = mapper.Map<LinkViewModel, LinkDTO>(model);
            await linkService.UpdateLink(linkDto);
            return RedirectToAction("Index", "Home");
        }
        return View(model);
    }

    public async Task<IActionResult> Delete(int id)
    {
 
            var linkDto = await linkService.GetLinkById(id);
            if (linkDto == null)
            {
                return NotFound();
            }
            await linkService.RemoveLink(id);
            return RedirectToAction("Index", "Home");


    }
}

