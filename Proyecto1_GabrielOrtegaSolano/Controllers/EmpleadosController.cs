using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1_GabrielOrtegaSolano.Models;

namespace Proyecto1_GabrielOrtegaSolano.Controllers
{
    public class EmpleadosController : Controller
    {
        private static List<Empleado> empleados = new List<Empleado>();
        // GET: EmpleadosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EmpleadosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
            return View();
        }

        // POST: EmpleadosController/Delete/5
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
