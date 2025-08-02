using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using ProyectoWebMVC.Models;
using ProyectoWebMVC.Datos;

namespace ProyectoWebMVC.Controllers
{
    public class VehiculosController : Controller
    {
        private readonly HttpClient _http;

        public VehiculosController(IHttpClientFactory httpClientFactory)
        {
            _http = httpClientFactory.CreateClient();
            _http.BaseAddress = new Uri("http://localhost:5219");
        }
        // GET: VehiculosController
        public async Task<IActionResult> Index(string filtro)
        {
            List<Vehiculo> vehiculos = new();

            if (string.IsNullOrEmpty(filtro))
            {
                vehiculos = await _http.GetFromJsonAsync<List<Vehiculo>>("api/vehiculos");
            }
            else
            {
                vehiculos = await _http.GetFromJsonAsync<List<Vehiculo>>($"api/vehiculos?filtro={filtro}");
            }

            return View(vehiculos);
        }

        // GET: VehiculosController/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            var vehiculo = await _http.GetFromJsonAsync<Vehiculo>($"api/vehiculos/{id}");
            if (vehiculo == null) return NotFound();
            return View(vehiculo);
        }

        // GET: VehiculosController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehiculosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vehiculo nuevoVehiculo)
        {
            var response = await _http.PostAsJsonAsync("api/vehiculos", nuevoVehiculo);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View(nuevoVehiculo);
        }

        // GET: VehiculosController/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            var vehiculo = await _http.GetFromJsonAsync<Vehiculo>($"api/vehiculos/{id}");
            if (vehiculo == null) return NotFound();

            return View(vehiculo);
        }

        // POST: VehiculosController/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Vehiculo vehiculoEditado)
        {
            var response = await _http.PutAsJsonAsync($"api/vehiculos/{vehiculoEditado.Placa}", vehiculoEditado);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View(vehiculoEditado);
        }

        // GET: VehiculosController/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            var vehiculo = await _http.GetFromJsonAsync<Vehiculo>($"api/vehiculos/{id}");
            if (vehiculo == null) return NotFound();
            return View(vehiculo);
        }

        // POST: VehiculosController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var response = await _http.DeleteAsync($"api/vehiculos/{id}");
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View();
        }
    }
}
