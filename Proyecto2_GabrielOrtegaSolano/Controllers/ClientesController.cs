using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto2_GabrielOrtegaSolano.Models;
using ProyectoWebMVC.Datos;

namespace Proyecto2_GabrielOrtegaSolano.Controllers
{
    public class ClientesController : Controller
    {
        private static Clientes servicio = new Clientes();
        // GET: ClientesController
        public ActionResult Index(string filtro)
        {
            var lista = string.IsNullOrEmpty(filtro)
               ? servicio.ObtenerTodos()
               : servicio.Buscar(filtro);

            return View(lista);

        }

        // GET: ClientesController/Details/5
        public ActionResult Details(int id)
        {
            var cliente = servicio.BuscarPorId(id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        // GET: ClientesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente clienteNuevo)
        {
            servicio.Crear(clienteNuevo);
            return RedirectToAction(nameof(Index));
        }

        // GET: ClientesController/Edit/5
        public ActionResult Edit(int id)
        {
            var cliente = servicio.BuscarPorId(id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        // POST: ClientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente clienteEditado)
        {
            servicio.Editar(clienteEditado);
            return RedirectToAction(nameof(Index));
        }

        // GET: ClientesController/Delete/5
        public ActionResult Delete(int id)
        {
            var cliente = servicio.BuscarPorId(id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        // POST: ClientesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            servicio.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
