using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Proyecto1_GabrielOrtegaSolano.Models;

namespace Proyecto1_GabrielOrtegaSolano.Controllers
{
    public class VehiculosController : Controller
    {
        private static List<Vehiculo> vehiculos = new List<Vehiculo>();
        // GET: VehiculosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: VehiculosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VehiculosController/Delete/5
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
