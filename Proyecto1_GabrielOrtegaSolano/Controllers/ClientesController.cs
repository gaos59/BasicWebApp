using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1_GabrielOrtegaSolano.Models;

namespace Proyecto1_GabrielOrtegaSolano.Controllers
{
    public class ClientesController : Controller
    {
        private static List<Cliente> clientes = new List<Cliente>();
        // GET: ClientesController
        public ActionResult Index(string filtro)
        {
            Cliente cliente = new Cliente();
            if (!clientes.Any()) { clientes.Add(cliente); }

            var listaFiltrada = clientes;


            if (!string.IsNullOrEmpty(filtro))
            {
                listaFiltrada = clientes
                    .Where(c =>
                        c.NombreCompleto.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                        c.Identificacion.ToString().Contains(filtro)
                    ).ToList();
            }



            return View(listaFiltrada);
            
        }

        // GET: ClientesController/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                Cliente clienteDetalle= clientes.FirstOrDefault(cliente => cliente.Identificacion == id);
                if (clienteDetalle == null)
                {
                    return NotFound();
                }
                return View(clienteDetalle);
            }
            catch (Exception)
            {

                return View();
            }
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
            try
            {
                clientes.Remove(clientes.FirstOrDefault(cliente => cliente.Identificacion == 0));
                clientes.Add(clienteNuevo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientesController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                Cliente clienteEditar = clientes.FirstOrDefault(cliente => cliente.Identificacion == id);
                if (clienteEditar == null)
                {
                    return NotFound();
                }
                return View(clienteEditar);
            }
            catch (Exception)
            {

                return View();
            }
        }

        // POST: ClientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente clienteEditado)
        {
            try
            {
                Cliente clienteEditar = clientes.FirstOrDefault(cliente => cliente.Identificacion == clienteEditado.Identificacion);
                clienteEditar.Identificacion = clienteEditado.Identificacion;
                clienteEditar.DireccionExacta = clienteEditado.DireccionExacta;
                clienteEditar.Preferencia = clienteEditado.Preferencia;
                clienteEditar.Provincia = clienteEditado.Provincia;
                clienteEditar.Canton = clienteEditado.Canton;
                clienteEditar.Distrito = clienteEditado.Distrito;
                clienteEditar.Telefono = clienteEditado.Telefono;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientesController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cliente clienteRemover = clientes.FirstOrDefault(cliente => cliente.Identificacion == id);

            if (clienteRemover == null)
            {
                return NotFound();
            }

            return View(clienteRemover);
        }

        // POST: ClientesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Cliente clienteARemover = clientes.FirstOrDefault(cliente => cliente.Identificacion == id);
                if (clienteARemover == null)
                {
                    return NotFound();
                }

                clientes.Remove(clienteARemover);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}
