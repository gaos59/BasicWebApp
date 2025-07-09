using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Proyecto2_GabrielOrtegaSolano.Models;
using ProyectoWebMVC.Datos;

namespace Proyecto2_GabrielOrtegaSolano.Controllers
{
    public class EmpleadosController : Controller
    {
        private static Empleados servicio = new Empleados();
        // GET: EmpleadosController
        public ActionResult Index(string filtro)
        {

            var lista = string.IsNullOrEmpty(filtro)
              ? servicio.ObtenerTodos()
              : servicio.Buscar(filtro);

            return View(lista);
        }

        // GET: EmpleadosController/Details/5
        public ActionResult Details(int id)
        {
            var empleado = servicio.BuscarPorId(id);
            if (empleado == null) return NotFound();
            return View(empleado);
        }

        // GET: EmpleadosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpleadosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Empleado nuevoEmpleado)
        {
            servicio.Crear(nuevoEmpleado);
            return RedirectToAction(nameof(Index));
        }

        // GET: EmpleadosController/Edit/5
        public ActionResult Edit(int id)
        {
            var empleado = servicio.BuscarPorId(id);
            if (empleado == null) return NotFound();
            return View(empleado);
        }

        // POST: EmpleadosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Empleado empleadoEditado)
        {
            servicio.Editar(empleadoEditado);
            return RedirectToAction(nameof(Index));
        }

        // GET: EmpleadosController/Delete/5
        public ActionResult Delete(int id)
        {
            var empleado = servicio.BuscarPorId(id);
            if (empleado == null) return NotFound();
            return View(empleado);
        }

        // POST: EmpleadosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            servicio.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
