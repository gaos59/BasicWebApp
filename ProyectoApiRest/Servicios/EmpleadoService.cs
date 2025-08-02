using Microsoft.EntityFrameworkCore;
using ProyectoApiRest.Datos;
using ProyectoWebMVC.Models;

namespace ProyectoApiRest.Servicios
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly DbContexto _context;

        public EmpleadoService(DbContexto context)
        {
            _context = context;
        }

        public List<Empleado> ObtenerTodos()
        {
            return _context.Empleados.ToList();
        }

        public List<Empleado> Buscar(string filtro)
        {
            return _context.Empleados
                .Where(e => e.Cedula.ToString().Contains(filtro))
                .ToList();
        }

        public Empleado BuscarPorId(int id)
        {
            return _context.Empleados.FirstOrDefault(e => e.Cedula == id);
        }

        public void Crear(Empleado nuevo)
        {
            _context.Empleados.Add(nuevo);
            _context.SaveChanges();
        }

        public void Editar(Empleado actualizado)
        {
            var empleado = BuscarPorId(actualizado.Cedula);
            if (empleado != null)
            {
                empleado.FechaNacimiento = actualizado.FechaNacimiento;
                empleado.FechaIngreso = actualizado.FechaIngreso;
                empleado.FechaRetiro = actualizado.FechaRetiro;
                empleado.SalarioPorDia = actualizado.SalarioPorDia;
                empleado.DiasVacaciones = actualizado.DiasVacaciones;
                empleado.MontoLiquidacion = actualizado.MontoLiquidacion;

                _context.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            var empleado = BuscarPorId(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
                _context.SaveChanges();
            }
        }
    }
}
