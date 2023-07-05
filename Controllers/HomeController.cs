using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Hello.Models;

namespace Hello.Controllers;

public class HomeController : Controller
{
    private List<Serie> _series = new List<Serie>();
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View(_series);
    }

    // GET: /Add/
    public string Add(string nome, int interesse)
    {
        _series.Add(new Serie(nome, interesse));
        _logger.LogInformation($"Nome = {nome} e Interesse = {interesse}");
        return "OK.";
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
