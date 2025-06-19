using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1_GabrielOrtegaSolano.Models;

namespace Proyecto1_GabrielOrtegaSolano.Controllers
{
    public class LavadosController : Controller
    {
        private static List<Lavado> lavados = new List<Lavado>();
        // GET: LavadosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LavadosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
            try
            {
                lavados.Add(nuevoLavado);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LavadosController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Lavado lavadoEditar = lavados.FirstOrDefault(lavado => lavado.IdLavado == id);
                return View(lavadoEditar);
            }
            catch (Exception)
            {

                return View();
            }
        }

        // POST: LavadosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Lavado lavadoEditado)
        {
            try
            {
                Lavado lavadoEditar = lavados.FirstOrDefault(lavado => lavado.IdLavado == lavadoEditado.IdLavado);
                lavadoEditar.IdLavado = lavadoEditado.IdLavado;
                lavadoEditar.PlacaVehiculo = lavadoEditado.PlacaVehiculo;
                lavadoEditar.IdCliente = lavadoEditado.IdCliente;
                lavadoEditar.IdEmpleado = lavadoEditado.IdEmpleado;
                lavadoEditar.Tipo = lavadoEditado.Tipo;
                lavadoEditar.Precio = lavadoEditado.Precio;
                lavadoEditar.IVA = lavadoEditado.IVA;
                lavadoEditar.Estado = lavadoEditado.Estado;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LavadosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LavadosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
