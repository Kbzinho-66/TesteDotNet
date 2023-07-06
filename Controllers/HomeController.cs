using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Hello.Models;

namespace Hello.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Serie> _series = new();
        return View(_series);
    }

    public IActionResult Add(string nome, int interesse)
    {
        _logger.LogInformation($"Adicionada série {nome} com interesse {interesse}");
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Exemplo()
    {
        var _series = new Serie[]
        {
            new Serie("Wakfu", 0),
            new Serie("The Wire", 1),
            new Serie("Seinfeld", -1),
            new Serie("Barry", 1),
            new Serie("The Expanse", 1),
        };
        return View("Index", _series);
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
