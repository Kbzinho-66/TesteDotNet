using System;
using System.Globalization;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Hello.Models;
using RestSharp;

namespace Hello.Controllers;

public class ApiController : Controller
{
    private readonly ILogger<ApiController> _logger;

    private static string[] tiposEn = new string[] {
        "education", "recreational", "social",
        "diy", "charity", "cooking", 
        "relaxation", "music", "busywork"
    };

    private static string[] tiposPt = new string[] {
        "Educativa", "Divertida", "Social",
        "Gambiarra", "Caridade", "Cozinha", 
        "Relaxante", "Música", "Mata Tempo"
    };

    public ApiController(ILogger<ApiController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<ActionResult> Procura(double dificuldade, int tipo, int participantes)
    {
        if (dificuldade != 1)
        {
            // Vem errado quando é decimal
            dificuldade /= 100.0;
        }
        var difFormat = dificuldade.ToString("n2", CultureInfo.InvariantCulture);
        var difFormat = dificuldade.ToString("n2", CultureInfo.InvariantCulture);

        var tipoEn = tiposEn[tipo];
        var tipoPt = tiposPt[tipo];

        var options = new RestClientOptions("https://www.boredapi.com/api/");
        var client = new RestClient(options);

        Resposta resposta = await client.GetJsonAsync<Resposta>(
            $"activity?type={tipoEn}&participants={participantes}&maxaccessibility={difFormat}"
            $"activity?type={tipoEn}&participants={participantes}&maxaccessibility={difFormat}"
        );

        return View(new Atividade(resposta, tipoPt));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
