using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Hello.Models;
using System.Text.Encodings.Web;

namespace Hello.Controllers;

public class EscolhaController : Controller
{
    private readonly ILogger<EscolhaController> _logger;

    public EscolhaController(ILogger<EscolhaController> logger)
    {
        _logger = logger;
    }

    //
    // GET: /Escolha/
    public string Index()
    {
        return "Padrão...";
    }

    // GET: /Escolha/Mostra/
    public IActionResult Mostra(string nome)
    {
        var serie = new Serie(nome, 0);
        return View(serie);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
