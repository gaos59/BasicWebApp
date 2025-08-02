using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using ProyectoWebMVC.Models;
using ProyectoWebMVC.Datos;

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
        public IActionResult Create()
        {
            return View();
        }


        // POST: LavadosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Lavado nuevoLavado)
        {
            var response = await _http.PostAsJsonAsync("api/lavados", nuevoLavado);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View(nuevoLavado);
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
