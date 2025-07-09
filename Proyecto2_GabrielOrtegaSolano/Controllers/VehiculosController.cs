using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Proyecto2_GabrielOrtegaSolano.Models;
using ProyectoWebMVC.Datos;

namespace Proyecto2_GabrielOrtegaSolano.Controllers
{
    public class VehiculosController : Controller
    {
        private static Vehiculos servicio = new Vehiculos();
        // GET: VehiculosController
        public ActionResult Index(string filtro)
        {
            var lista = string.IsNullOrEmpty(filtro)
                ? servicio.ObtenerTodos()
                : servicio.Buscar(filtro);

            return View(lista);
        }

        // GET: VehiculosController/Details/5
        public ActionResult Details(string id)
        {
            var vehiculo = servicio.BuscarPorPlaca(id);
            if (vehiculo == null) return NotFound();
            return View(vehiculo);
        }

        // GET: VehiculosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehiculosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vehiculo nuevoVehiculo)
        {
            servicio.Crear(nuevoVehiculo);
            return RedirectToAction(nameof(Index));
        }

        // GET: VehiculosController/Edit/5
        public ActionResult Edit(string id)
        {
            var vehiculo = servicio.BuscarPorPlaca(id);
            if (vehiculo == null) return NotFound();
            return View(vehiculo);
        }

        // POST: VehiculosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vehiculo vehiculoEditado)
        {
            servicio.Editar(vehiculoEditado);
            return RedirectToAction(nameof(Index));
        }

        // GET: VehiculosController/Delete/5
        public ActionResult Delete(string id)
        {
            var vehiculo = servicio.BuscarPorPlaca(id);
            if (vehiculo == null) return NotFound();
            return View(vehiculo);
        }

        // POST: VehiculosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            servicio.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
