using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Proyecto2_GabrielOrtegaSolano.Models;

namespace Proyecto2_GabrielOrtegaSolano.Controllers
{
    public class EmpleadosController : Controller
    {
        private static List<Empleado> empleados = new List<Empleado>();
        // GET: EmpleadosController
        public ActionResult Index(string filtro)
        {

            Empleado empleado = new Empleado();
            if (!empleados.Any()) { empleados.Add(empleado); }

            var listaFiltrada = empleados;


            if (!string.IsNullOrEmpty(filtro))
            {
                listaFiltrada = empleados.Where(e =>e.Cedula.ToString().Contains(filtro)).ToList();
            }



            return View(listaFiltrada);
        }

        // GET: EmpleadosController/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                Empleado empleadoDetalle = empleados.FirstOrDefault(empleado => empleado.Cedula == id);
                if (empleadoDetalle == null)
                {
                    return NotFound();
                }
                return View(empleadoDetalle);
            }
            catch (Exception)
            {

                return View();
            }
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
            try
            {
                empleados.Remove(empleados.FirstOrDefault(empleado => empleado.Cedula == 0));
                empleados.Add(nuevoEmpleado);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadosController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Empleado empleadoEditar = empleados.FirstOrDefault(empleado => empleado.Cedula == id);
                return View(empleadoEditar);
            }
            catch (Exception)
            {

                return View();
            }
        }

        // POST: EmpleadosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Empleado empleadoEditado)
        {
            try
            {
                Empleado empleadoEditar = empleados.FirstOrDefault(empleado => empleado.Cedula == empleado.Cedula);
                empleadoEditar.Cedula = empleadoEditado.Cedula;
                empleadoEditar.FechaNacimiento = empleadoEditado.FechaNacimiento;
                empleadoEditar.FechaIngreso = empleadoEditado.FechaIngreso;
                empleadoEditar.FechaRetiro = empleadoEditado.FechaRetiro;
                empleadoEditar.SalarioPorDia = empleadoEditado.SalarioPorDia;
                empleadoEditar.DiasVacaciones = empleadoEditado.DiasVacaciones;
                empleadoEditar.MontoLiquidacion = empleadoEditado.MontoLiquidacion;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadosController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Empleado empleadoRemover = empleados.FirstOrDefault(empleado => empleado.Cedula == id);

            if (empleadoRemover == null)
            {
                return NotFound();
            }

            return View(empleadoRemover);
        }

        // POST: EmpleadosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Empleado empleadoRemover = empleados.FirstOrDefault(empleado => empleado.Cedula == id);
                if (empleadoRemover == null)
                {
                    return NotFound();
                }

                empleados.Remove(empleadoRemover);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}
