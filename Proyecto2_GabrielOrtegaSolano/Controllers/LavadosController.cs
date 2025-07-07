using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Proyecto2_GabrielOrtegaSolano.Models;

namespace Proyecto2_GabrielOrtegaSolano.Controllers
{
    public class LavadosController : Controller
    {
        private static List<Lavado> lavados = new List<Lavado>();
        // GET: LavadosController
        public ActionResult Index(string filtro)
        {
            Lavado lavado = new Lavado();
            if (!lavados.Any()) { lavados.Add(lavado); }

            var listaFiltrada = lavados;


            if (!string.IsNullOrEmpty(filtro))
            {
                listaFiltrada = lavados.Where(l => l.IdLavado.ToString().Contains(filtro) || l.PlacaVehiculo.Contains(filtro)).ToList();
            }



            return View(listaFiltrada);
        }

        // GET: LavadosController/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                Lavado lavadoDetalle = lavados.FirstOrDefault(lavado => lavado.IdLavado == id);
                if (lavadoDetalle == null)
                {
                    return NotFound();
                }
                return View(lavadoDetalle);
            }
            catch (Exception)
            {

                return View();
            }
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
                lavados.Remove(lavados.FirstOrDefault(lavado => lavado.PlacaVehiculo == null));
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
            if (id == null)
            {
                return NotFound();
            }

            Lavado lavadoRemover = lavados.FirstOrDefault(lavado => lavado.IdLavado == id);

            if (lavadoRemover == null)
            {
                return NotFound();
            }

            return View(lavadoRemover);
        }

        // POST: LavadosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Lavado lavadoRemover = lavados.FirstOrDefault(lavado => lavado.IdLavado == id);
                if (lavadoRemover == null)
                {
                    return NotFound();
                }

                lavados.Remove(lavadoRemover);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}
