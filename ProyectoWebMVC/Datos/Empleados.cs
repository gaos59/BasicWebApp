using ProyectoWebMVC.Models;

namespace ProyectoWebMVC.Datos
{
    public class Empleados
    {
        private static List<Empleado> empleados = new List<Empleado>
        {
            new Empleado
            {
                Cedula = 0,
                FechaNacimiento = new DateTime(1990, 1, 1),
                FechaIngreso = DateTime.Today.AddYears(-2),
                SalarioPorDia = 20000,
                DiasVacaciones = 10,
                FechaRetiro = DateTime.Today.AddYears(+2),
                MontoLiquidacion = 0
            }
        };

        public List<Empleado> ObtenerTodos()
        {
            return empleados;
        }

        public List<Empleado> Buscar(string filtro)
        {
            return empleados.Where(e => e.Cedula.ToString().Contains(filtro)).ToList();
        }

        public Empleado BuscarPorId(int id)
        {
            return empleados.FirstOrDefault(e => e.Cedula == id);
        }

        public void Crear(Empleado nuevo)
        {
            empleados.Remove(empleados.FirstOrDefault(empleado => empleado.Cedula == 0));
            empleados.Add(nuevo);
        }

        public void Editar(Empleado actualizado)
        {
            var empleado = empleados.FirstOrDefault(e => e.Cedula == actualizado.Cedula);
            if (empleado != null)
            {
                empleado.FechaNacimiento = actualizado.FechaNacimiento;
                empleado.FechaIngreso = actualizado.FechaIngreso;
                empleado.FechaRetiro = actualizado.FechaRetiro;
                empleado.SalarioPorDia = actualizado.SalarioPorDia;
                empleado.DiasVacaciones = actualizado.DiasVacaciones;
                empleado.MontoLiquidacion = actualizado.MontoLiquidacion;
            }
        }

        public void Eliminar(int id)
        {
            var empleado = empleados.FirstOrDefault(e => e.Cedula == id);
            if (empleado != null)
            {
                empleados.Remove(empleado);
            }
        }
    }
}
