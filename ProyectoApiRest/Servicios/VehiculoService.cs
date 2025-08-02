using Microsoft.EntityFrameworkCore;
using ProyectoApiRest.Datos;
using ProyectoWebMVC.Models;

namespace ProyectoApiRest.Servicios
{
    public class VehiculoService : IVehiculoService
    {
        private readonly DbContexto _context;

        public VehiculoService(DbContexto context)
        {
            _context = context;
        }

        public List<Vehiculo> ObtenerTodos()
        {
            return _context.Vehiculos.ToList();
        }

        public List<Vehiculo> Buscar(string filtro)
        {
            return _context.Vehiculos
                .Where(v =>
                    (!string.IsNullOrEmpty(v.Placa) && v.Placa.Contains(filtro)) ||
                    (!string.IsNullOrEmpty(v.Marca) && v.Marca.Contains(filtro))
                ).ToList();
        }

        public Vehiculo BuscarPorPlaca(string placa)
        {
            return _context.Vehiculos.FirstOrDefault(v => v.Placa == placa);
        }

        public void Crear(Vehiculo nuevo)
        {
            _context.Vehiculos.Add(nuevo);
            _context.SaveChanges();
        }

        public void Editar(Vehiculo actualizado)
        {
            var vehiculo = BuscarPorPlaca(actualizado.Placa);
            if (vehiculo != null)
            {
                vehiculo.Marca = actualizado.Marca;
                vehiculo.Modelo = actualizado.Modelo;
                vehiculo.Traccion = actualizado.Traccion;
                vehiculo.Color = actualizado.Color;
                vehiculo.UltimaFechaAtencion = actualizado.UltimaFechaAtencion;
                vehiculo.TratamientoEspecial = actualizado.TratamientoEspecial;

                _context.SaveChanges();
            }
        }

        public void Eliminar(string placa)
        {
            var vehiculo = BuscarPorPlaca(placa);
            if (vehiculo != null)
            {
                _context.Vehiculos.Remove(vehiculo);
                _context.SaveChanges();
            }
        }
    }
}
