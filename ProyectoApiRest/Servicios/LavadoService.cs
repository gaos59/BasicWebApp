using Microsoft.EntityFrameworkCore;
using ProyectoApiRest.Datos;
using ProyectoWebMVC.Models;
using static ProyectoWebMVC.Models.Lavado;

namespace ProyectoApiRest.Servicios
{
    public class LavadoService : ILavadoService
    {
        private readonly DbContexto _context;

        public LavadoService(DbContexto context)
        {
            _context = context;
        }

        public List<Lavado> ObtenerTodos()
        {
            return _context.Lavados.ToList();
        }

        public List<Lavado> Buscar(string filtro)
        {
            return _context.Lavados
                .Where(l =>
                    l.IdLavado.ToString().Contains(filtro) ||
                    (!string.IsNullOrEmpty(l.PlacaVehiculo) && l.PlacaVehiculo.Contains(filtro))
                )
                .ToList();
        }

        public Lavado BuscarPorId(int id)
        {
            return _context.Lavados.FirstOrDefault(l => l.IdLavado == id);
        }

        public void Crear(Lavado nuevo)
        {
            _context.Lavados.Add(nuevo);
            _context.SaveChanges();
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

                _context.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            var lavado = BuscarPorId(id);
            if (lavado != null)
            {
                _context.Lavados.Remove(lavado);
                _context.SaveChanges();
            }
        }
    }
}
