using ProyectoWebMVC.Models;

namespace ProyectoApiRest.Servicios
{
    public class EmpleadoService : IEmpleadoService
    {
        private static List<Empleado> empleados = new List<Empleado>
        {
            new Empleado
            {
                Cedula = 14435567,
                FechaNacimiento = new DateTime(1990, 1, 1),
                FechaIngreso = DateTime.Today.AddYears(-2),
                SalarioPorDia = 20000,
                DiasVacaciones = 10,
                FechaRetiro = DateTime.Today.AddYears(+2),
                MontoLiquidacion = 865785
            },
            new Empleado
            {
                Cedula = 343255534,
                FechaNacimiento = new DateTime(1998, 1, 1),
                FechaIngreso = DateTime.Today.AddYears(-4),
                SalarioPorDia = 20000,
                DiasVacaciones = 10,
                FechaRetiro = DateTime.Today.AddYears(+2),
                MontoLiquidacion = 567577
            },
            new Empleado
            {
                Cedula = 566744576,
                FechaNacimiento = new DateTime(1985, 1, 1),
                FechaIngreso = DateTime.Today.AddYears(-10),
                SalarioPorDia = 20000,
                DiasVacaciones = 10,
                FechaRetiro = DateTime.Today.AddYears(+6),
                MontoLiquidacion = 4078065
            }
        };

        public List<Empleado> ObtenerTodos()
        {
            return empleados;
        }

        public List<Empleado> Buscar(string filtro)
        {
            return empleados.Where(e =>
                e.Cedula.ToString().Contains(filtro)
            ).ToList();
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
            var empleado = BuscarPorId(actualizado.Cedula);
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
            var empleado = BuscarPorId(id);
            if (empleado != null)
            {
                empleados.Remove(empleado);
            }
        }
    }
}
