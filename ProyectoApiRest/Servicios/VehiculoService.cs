using Proyecto2_GabrielOrtegaSolano.Models;

namespace ProyectoApiRest.Servicios
{
    public class VehiculoService : IVehiculoService
    {
        private static List<Vehiculo> vehiculos = new List<Vehiculo>
        {
            new Vehiculo
            {
                Placa = "734577",
                Marca = "Toyota",
                Modelo = "Corolla",
                Traccion = "4x2",
                Color = "Rojo",
                UltimaFechaAtencion = DateTime.Today.AddDays(-40),
                TratamientoEspecial = true
            },
            new Vehiculo
            {
                Placa = "365785",
                Marca = "Chevrolet",
                Modelo = "Spark",
                Traccion = "4x2",
                Color = "Blanco",
                UltimaFechaAtencion = DateTime.Today.AddDays(-20),
                TratamientoEspecial = true
            },
            new Vehiculo
            {
                Placa = "868997",
                Marca = "Mitsubishi",
                Modelo = "Montero",
                Traccion = "4x4",
                Color = "Negro",
                UltimaFechaAtencion = DateTime.Today.AddDays(-33),
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
            vehiculos.Remove(vehiculos.FirstOrDefault(vehiculo => vehiculo.Placa == null || vehiculo.Placa == ""));
            vehiculos.Add(nuevo);
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
            }
        }

        public void Eliminar(string placa)
        {
            var vehiculo = BuscarPorPlaca(placa);
            if (vehiculo != null)
            {
                vehiculos.Remove(vehiculo);
            }
        }
    }
}
