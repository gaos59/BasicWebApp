using ProyectoWebMVC.Models;
using static ProyectoWebMVC.Models.Lavado;

namespace ProyectoApiRest.Servicios
{
    public class LavadoService : ILavadoService
    {
        private static List<Lavado> lavados = new List<Lavado>
        {
            new Lavado
            {
                IdLavado = 7,
                PlacaVehiculo = "534536",
                IdCliente = 101457455,
                IdEmpleado = 575685658,
                Tipo = TipoLavado.Lajoya,
                Precio = 8000,
                Estado = EstadoLavado.EnProceso
            },
            new Lavado
            {
                IdLavado = 4,
                PlacaVehiculo = "765476",
                IdCliente = 101457455,
                IdEmpleado = 575685658,
                Tipo = TipoLavado.Premium,
                Precio = 10000,
                Estado = EstadoLavado.Agendado
            },
            new Lavado
            {
                IdLavado = 2,
                PlacaVehiculo = "859876",
                IdCliente = 101457455,
                IdEmpleado = 575685658,
                Tipo = TipoLavado.Basico,
                Precio = 4000,
                Estado = EstadoLavado.Facturado
            }
        };

        public List<Lavado> ObtenerTodos()
        {
            return lavados;
        }

        public List<Lavado> Buscar(string filtro)
        {
            return lavados.Where(l =>
                l.IdLavado.ToString().Contains(filtro) ||
                (!string.IsNullOrEmpty(l.PlacaVehiculo) && l.PlacaVehiculo.Contains(filtro, StringComparison.OrdinalIgnoreCase))
            ).ToList();
        }

        public Lavado BuscarPorId(int id)
        {
            return lavados.FirstOrDefault(l => l.IdLavado == id);
        }

        public void Crear(Lavado nuevo)
        {
            lavados.Remove(lavados.FirstOrDefault(lavado => lavado.PlacaVehiculo == null));
            lavados.Add(nuevo);
        }

        public void Editar(Lavado actualizado)
        {
            var lavado = BuscarPorId(actualizado.IdLavado);
            if (lavado != null)
            {
                lavado.PlacaVehiculo = actualizado.PlacaVehiculo;
                lavado.IdCliente = actualizado.IdCliente;
                lavado.IdEmpleado = actualizado.IdEmpleado;
                lavado.Tipo = actualizado.Tipo;
                lavado.Precio = actualizado.Precio;
                lavado.Estado = actualizado.Estado;
            }
        }

        public void Eliminar(int id)
        {
            var lavado = BuscarPorId(id);
            if (lavado != null)
            {
                lavados.Remove(lavado);
            }
        }
    }
}
