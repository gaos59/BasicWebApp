using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Proyecto2_GabrielOrtegaSolano.Models;
using ProyectoWebMVC.Datos;

namespace Proyecto2_GabrielOrtegaSolano.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly HttpClient _http;

        public EmpleadosController(IHttpClientFactory httpClientFactory)
        {
            _http = httpClientFactory.CreateClient();
            _http.BaseAddress = new Uri("http://localhost:5219");
        }
        // GET: EmpleadosController
        public async Task<IActionResult> Index(string filtro)
        {
            List<Empleado> empleados = new();

            if (string.IsNullOrEmpty(filtro))
            {
                empleados = await _http.GetFromJsonAsync<List<Empleado>>("api/empleados");
            }
            else
            {
                empleados = await _http.GetFromJsonAsync<List<Empleado>>($"api/empleados?filtro={filtro}");
            }

            return View(empleados);
        }

        // GET: EmpleadosController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var empleado = await _http.GetFromJsonAsync<Empleado>($"api/empleados/{id}");
            if (empleado == null) return NotFound();
            return View(empleado);
        }

        // GET: EmpleadosController/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: EmpleadosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Empleado nuevoEmpleado)
        {
            var response = await _http.PostAsJsonAsync("api/empleados", nuevoEmpleado);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View(nuevoEmpleado);
        }

        // GET: EmpleadosController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var empleado = await _http.GetFromJsonAsync<Empleado>($"api/empleados/{id}");
            if (empleado == null) return NotFound();
            return View(empleado);
        }

        // POST: EmpleadosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Empleado empleadoEditado)
        {
            var response = await _http.PutAsJsonAsync($"api/empleados/{empleadoEditado.Cedula}", empleadoEditado);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View(empleadoEditado);
        }

        // GET: EmpleadosController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var empleado = await _http.GetFromJsonAsync<Empleado>($"api/empleados/{id}");
            if (empleado == null) return NotFound();
            return View(empleado);
        }


        // POST: EmpleadosController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _http.DeleteAsync($"api/empleados/{id}");
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View();
        }
    }
}
