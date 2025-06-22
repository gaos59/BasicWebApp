using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Proyecto1_GabrielOrtegaSolano.Models;

namespace Proyecto1_GabrielOrtegaSolano.Controllers
{
    public class VehiculosController : Controller
    {
        private static List<Vehiculo> vehiculos = new List<Vehiculo>();
        // GET: VehiculosController
        public ActionResult Index(string filtro)
        {
            Vehiculo vehiculo = new Vehiculo();
            if (!vehiculos.Any()) { vehiculos.Add(vehiculo); }

            var listaFiltrada = vehiculos;


            if (!string.IsNullOrEmpty(filtro))
            {
                listaFiltrada = vehiculos.Where(v => v.Marca.Contains(filtro) || v.Placa.Contains(filtro)).ToList();
            }



            return View(listaFiltrada);            
        }

        // GET: VehiculosController/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                Vehiculo vehiculoDetalle = vehiculos.FirstOrDefault(vehiculo => vehiculo.Placa == id);
                if (vehiculoDetalle == null)
                {
                    return NotFound();
                }
                return View(vehiculoDetalle);
            }
            catch (Exception)
            {

                return View();
            }
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
            try
            {
                vehiculos.Remove(vehiculos.FirstOrDefault(vehiculo => vehiculo.Placa == null));
                vehiculos.Add(nuevoVehiculo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehiculosController/Edit/5
        public ActionResult Edit(string id)
        {
            try
            {
                Vehiculo vehiculoEditar = vehiculos.FirstOrDefault(vehiculo => vehiculo.Placa == id);
                return View(vehiculoEditar);
            }
            catch (Exception)
            {

                return View();
            }           
        }

        // POST: VehiculosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vehiculo vehiculoEditado)
        {
            try
            {
                Vehiculo vehiculoEditar = vehiculos.FirstOrDefault(vehiculo => vehiculo.Placa == vehiculoEditado.Placa);
                vehiculoEditar.Placa = vehiculoEditado.Placa;
                vehiculoEditar.Marca = vehiculoEditado.Marca;
                vehiculoEditar.Modelo = vehiculoEditado.Modelo;
                vehiculoEditar.Traccion = vehiculoEditado.Traccion;
                vehiculoEditar.Color = vehiculoEditado.Color;
                vehiculoEditar.UltimaFechaAtencion = vehiculoEditado.UltimaFechaAtencion;
                vehiculoEditar.TratamientoEspecial = vehiculoEditado.TratamientoEspecial;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehiculosController/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vehiculo vehiculoRemover = vehiculos.FirstOrDefault(vehiculo => vehiculo.Placa == id);

            if (vehiculoRemover == null)
            {
                return NotFound();
            }

            return View(vehiculoRemover);
        }

        // POST: VehiculosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {

            try
            {
                Vehiculo vehiculoRemover = vehiculos.FirstOrDefault(vehiculo => vehiculo.Placa == id);
                if (vehiculoRemover == null)
                {
                    return NotFound();
                }

                vehiculos.Remove(vehiculoRemover);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}
