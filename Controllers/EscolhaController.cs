using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Hello.Models;
using System.Text.Encodings.Web;

namespace Hello.Controllers;

public class EscolhaController : Controller
{
    private readonly ILogger<EscolhaController> _logger;

    private static Serie PegaAleatoria(Serie[] series) {
        const int pesoBase = 2;
        var indices = new List<int>();

        int i = 0;
        foreach (var serie in series)
        {
            for (int j = 0; j < pesoBase + serie.Interesse; j++)
            {
                indices.Add(i);
            }
            i++;
        }

        var rand = new Random();
        var escolha = rand.Next(0, indices.Count);
        var indice = indices[escolha];
        return series[indice];
        
    }

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
    public IActionResult Mostra()
    {
        // Buscaria isso do DB
        var series = new Serie[]
        {
            new Serie("Wakfu", 0),
            new Serie("The Wire", 1),
            new Serie("Seinfeld", -1),
            new Serie("Barry", 1),
            new Serie("The Expanse", 1),
        };

        return View(PegaAleatoria(series));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
