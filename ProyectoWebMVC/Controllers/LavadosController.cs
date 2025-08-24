using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using ProyectoWebMVC.Datos;
using ProyectoWebMVC.Models;
using System.Reflection;

namespace ProyectoWebMVC.Controllers
{
    public class LavadosController : Controller
    {
        private readonly HttpClient _http;

        public LavadosController(IHttpClientFactory httpClientFactory)
        {
            _http = httpClientFactory.CreateClient();
            _http.BaseAddress = new Uri("http://localhost:5219");
        }
        // GET: LavadosController
        public async Task<IActionResult> Index(string filtro)
        {
            List<Lavado> lavados = new();

            if (string.IsNullOrEmpty(filtro))
            {
                lavados = await _http.GetFromJsonAsync<List<Lavado>>("api/lavados");
            }
            else
            {
                lavados = await _http.GetFromJsonAsync<List<Lavado>>($"api/lavados?filtro={filtro}");
            }

            return View(lavados);
        }

        // GET: LavadosController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var lavado = await _http.GetFromJsonAsync<Lavado>($"api/lavados/{id}");
            if (lavado == null) return NotFound();
            return View(lavado);
        }

        // GET: LavadosController/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = new LavadoViewModel();

            // Obtener los datos existentes
            var vehiculos = await _http.GetFromJsonAsync<List<Vehiculo>>("api/vehiculos");
            var clientes = await _http.GetFromJsonAsync<List<Cliente>>("api/clientes");
            var empleados = await _http.GetFromJsonAsync<List<Empleado>>("api/empleados");

            // Crear SelectLists
            viewModel.Vehiculos = vehiculos.Select(v => new SelectListItem
            {
                Value = v.Placa,
                Text = $"{v.Placa} - {v.Marca} {v.Modelo}"
            }).ToList();

            viewModel.Clientes = clientes.Select(c => new SelectListItem
            {
                Value = c.Identificacion.ToString(),
                Text = c.NombreCompleto
            }).ToList();

            viewModel.Empleados = empleados.Select(e => new SelectListItem
            {
                Value = e.Cedula.ToString(),
                Text = e.Cedula.ToString()
            }).ToList();

            return View(viewModel);
        }


        // POST: LavadosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LavadoViewModel model)
        {
            var response = await _http.PostAsJsonAsync("api/lavados", model.Lavado);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        // GET: LavadosController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var lavado = await _http.GetFromJsonAsync<Lavado>($"api/lavados/{id}");
            if (lavado == null) return NotFound();
            return View(lavado);
        }

        // POST: LavadosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Lavado lavadoEditado)
        {
            var response = await _http.PutAsJsonAsync($"api/lavados/{lavadoEditado.IdLavado}", lavadoEditado);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View(lavadoEditado);
        }

        // GET: LavadosController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var lavado = await _http.GetFromJsonAsync<Lavado>($"api/lavados/{id}");
            if (lavado == null) return NotFound();
            return View(lavado);
        }

        // POST: LavadosController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _http.DeleteAsync($"api/lavados/{id}");
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View();
        }
    }
}
