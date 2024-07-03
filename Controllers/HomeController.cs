using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PaqueteTuristico.Models;

namespace PaqueteTuristico.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index(Paquete paquete)
    {
        if(ORTWorld.Paquetes == null)
        {
            ViewBag.Paquetes = new Dictionary<string, Paquete>();
        }
        else
        {
            ViewBag.Paquetes = ORTWorld.Paquetes;
        }
        
        return View();
    }
    public IActionResult GuardarPaquete(int Destino, int Hotel, int Aereo, int Excursion)
    {
        if(Destino < 1 || Destino > ORTWorld.ListaDestinos.Count || Hotel < 1 || Hotel > ORTWorld.ListaHoteles.Count || Aereo < 1 || Aereo > ORTWorld.ListaAereos.Count || Excursion < 1 || Excursion > ORTWorld.ListaExcursiones.Count)
        {
            ViewBag.MensajeError = "Error, los inputs no han sido rellenados correctamente";
            ViewBag.Mensaje = "No se ha podido cargar el paquete, vuelva a intentarlo";
            ViewBag.ListaDestinos = ORTWorld.ListaDestinos;
            ViewBag.ListaHoteles = ORTWorld.ListaHoteles;
            ViewBag.ListaExcursiones = ORTWorld.ListaExcursiones;
            ViewBag.ListaAereos = ORTWorld.ListaAereos;
            return View("SelectPaquete");
        }
        else
        {
        Paquete paquete = new Paquete(ORTWorld.ListaHoteles[Hotel - 1], ORTWorld.ListaAereos[Aereo - 1], ORTWorld.ListaExcursiones[Excursion - 1]);
        string DestinoSeleccionado = ORTWorld.ListaDestinos[Destino - 1];
        bool existe = ORTWorld.ingresarPaquete(DestinoSeleccionado, paquete);
        ViewBag.Mensaje = "El paquete se ha guardado correctamente. Gracias por confiar en nosotros";
        
        }
        ViewBag.Paquetes = ORTWorld.Paquetes;
        ViewBag.ListaDestinos = ORTWorld.ListaDestinos;
        ViewBag.ListaHoteles = ORTWorld.ListaHoteles;
        ViewBag.ListaExcursiones = ORTWorld.ListaExcursiones;
        ViewBag.ListaAereos = ORTWorld.ListaAereos;
        return View("Index");
    }
    public IActionResult SelectPaquete()
    {
        ViewBag.ListaDestinos = ORTWorld.ListaDestinos;
        ViewBag.ListaHoteles = ORTWorld.ListaHoteles;
        ViewBag.ListaExcursiones = ORTWorld.ListaExcursiones;
        ViewBag.ListaAereos = ORTWorld.ListaAereos;
        return View();
    }
        
}