using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto2_GabrielOrtegaSolano.Models;

namespace ProyectoWebMVC.Controllers
{
    public class ReportesController : Controller
    {
        private readonly HttpClient _http;

        public ReportesController(IHttpClientFactory httpClientFactory)
        {
            _http = httpClientFactory.CreateClient();
            _http.BaseAddress = new Uri("http://localhost:5219");
        }

        // GET: Reportes/VehiculosSinLavado
        public async Task<IActionResult> VehiculosSinLavado()
        {
            var resultado = await _http.GetFromJsonAsync<List<Vehiculo>>("api/reportes/vehiculos-sin-lavado");
            return View(resultado);
        }
    }
}
