using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto2_GabrielOrtegaSolano.Models;
using ProyectoWebMVC.Datos;

namespace Proyecto2_GabrielOrtegaSolano.Controllers
{
    public class ClientesController : Controller
    {
        private readonly HttpClient _http;

        public ClientesController(IHttpClientFactory httpClientFactory)
        {
            _http = httpClientFactory.CreateClient();
            _http.BaseAddress = new Uri("http://localhost:5219");
        }
        // GET: ClientesController
        public async Task<IActionResult> Index(string filtro)
        {
            List<Cliente> clientes = new();

            if (string.IsNullOrEmpty(filtro))
            {
                clientes = await _http.GetFromJsonAsync<List<Cliente>>("api/clientes");
            }
            else
            {
                clientes = await _http.GetFromJsonAsync<List<Cliente>>($"api/clientes?filtro={filtro}");
            }

            return View(clientes);
        }

        // GET: ClientesController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var cliente = await _http.GetFromJsonAsync<Cliente>($"api/clientes/{id}");
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        // GET: ClientesController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente clienteNuevo)
        {
            var response = await _http.PostAsJsonAsync("api/clientes", clienteNuevo);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View(clienteNuevo);
        }

        // GET: ClientesController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var cliente = await _http.GetFromJsonAsync<Cliente>($"api/clientes/{id}");
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        // POST: ClientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Cliente clienteEditado)
        {
            var response = await _http.PutAsJsonAsync($"api/clientes/{clienteEditado.Identificacion}", clienteEditado);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View(clienteEditado);
        }

        // GET: ClientesController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _http.GetFromJsonAsync<Cliente>($"api/clientes/{id}");
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        // POST: ClientesController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _http.DeleteAsync($"api/clientes/{id}");
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View();
        }
    }
}
