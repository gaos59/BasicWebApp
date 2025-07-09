using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Proyecto2_GabrielOrtegaSolano.Models;
using ProyectoWebMVC.Datos;

namespace Proyecto2_GabrielOrtegaSolano.Controllers
{
    public class LavadosController : Controller
    {
        private static Lavados servicio = new Lavados();
        // GET: LavadosController
        public ActionResult Index(string filtro)
        {
            var lista = string.IsNullOrEmpty(filtro)
                 ? servicio.ObtenerTodos()
                 : servicio.Buscar(filtro);

            return View(lista);
        }

        // GET: LavadosController/Details/5
        public ActionResult Details(int id)
        {
            var lavado = servicio.BuscarPorId(id);
            if (lavado == null) return NotFound();
            return View(lavado);
        }

        // GET: LavadosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LavadosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Lavado nuevoLavado)
        {
            servicio.Crear(nuevoLavado);
            return RedirectToAction(nameof(Index));
        }

        // GET: LavadosController/Edit/5
        public ActionResult Edit(int id)
        {
            var lavado = servicio.BuscarPorId(id);
            if (lavado == null) return NotFound();
            return View(lavado);
        }

        // POST: LavadosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Lavado lavadoEditado)
        {
            servicio.Editar(lavadoEditado);
            return RedirectToAction(nameof(Index));
        }

        // GET: LavadosController/Delete/5
        public ActionResult Delete(int id)
        {
            var lavado = servicio.BuscarPorId(id);
            if (lavado == null) return NotFound();
            return View(lavado);
        }

        // POST: LavadosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            servicio.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
