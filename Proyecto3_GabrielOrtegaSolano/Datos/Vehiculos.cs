using ProyectoWebMVC.Models;

namespace ProyectoWebMVC.Datos
{
    public class Vehiculos
    {
        private static List<Vehiculo> vehiculos = new List<Vehiculo>
        {
            new Vehiculo
            {
                Placa = null,
                Marca = "Toyota",
                Modelo = "Corolla",
                Traccion = "4x2",
                Color = "Rojo",
                UltimaFechaAtencion = DateTime.Today.AddDays(-40),
                TratamientoEspecial = true
            }
        };

        public List<Vehiculo> ObtenerTodos()
        {
            return vehiculos;
        }

        public List<Vehiculo> Buscar(string filtro)
        {
            return vehiculos.Where(v =>
                (!string.IsNullOrEmpty(v.Placa) && v.Placa.Contains(filtro, StringComparison.OrdinalIgnoreCase)) ||
                (!string.IsNullOrEmpty(v.Marca) && v.Marca.Contains(filtro, StringComparison.OrdinalIgnoreCase))
            ).ToList();
        }

        public Vehiculo BuscarPorPlaca(string placa)
        {
            return vehiculos.FirstOrDefault(v => v.Placa == placa);
        }

        public void Crear(Vehiculo nuevo)
        {
            vehiculos.Remove(vehiculos.FirstOrDefault(vehiculo => vehiculo.Placa == null));
            vehiculos.Add(nuevo);
        }

        public void Editar(Vehiculo actualizado)
        {
            var v = vehiculos.FirstOrDefault(v => v.Placa == actualizado.Placa);
            if (v != null)
            {
                v.Marca = actualizado.Marca;
                v.Modelo = actualizado.Modelo;
                v.Traccion = actualizado.Traccion;
                v.Color = actualizado.Color;
                v.UltimaFechaAtencion = actualizado.UltimaFechaAtencion;
                v.TratamientoEspecial = actualizado.TratamientoEspecial;
            }
        }

        public void Eliminar(string placa)
        {
            var v = vehiculos.FirstOrDefault(v => v.Placa == placa);
            if (v != null)
            {
                vehiculos.Remove(v);
            }
        }
    }
}
