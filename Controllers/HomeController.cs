﻿using System.Diagnostics;
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
        return View();
    }

    // GET: /Add/
    public string Add(string nome, int interesse)
    {
        _logger.LogInformation($"Nome = {nome} e Interesse = {interesse}");
        return "OK.";
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
