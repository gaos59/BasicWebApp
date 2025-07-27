using Proyecto2_GabrielOrtegaSolano.Models;

namespace ProyectoApiRest.Servicios
{
    public class ClienteService : IClienteService
    {
        private static List<Cliente> clientes = new List<Cliente>
        {
            new Cliente { Identificacion = 23425656, NombreCompleto = "Federico Alvarado Perez" },
            new Cliente {Identificacion = 343255534, NombreCompleto = "Jose Ramirez Ulloa" },
            new Cliente {Identificacion = 566744576, NombreCompleto = "Patricia Gomez Ruiz" }
        };

        public List<Cliente> ObtenerTodos()
        {
            return clientes;
        }

        public List<Cliente> Buscar(string filtro)
        {
            return clientes.Where(c =>
                c.NombreCompleto.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                c.Identificacion.ToString().Contains(filtro)
            ).ToList();
        }

        public Cliente BuscarPorId(int id)
        {
            return clientes.FirstOrDefault(c => c.Identificacion == id);
        }

        public void Crear(Cliente nuevo)
        {
            clientes.Remove(clientes.FirstOrDefault(cliente => cliente.Identificacion == 0));
            clientes.Add(nuevo);
        }

        public void Editar(Cliente actualizado)
        {
            var cliente = BuscarPorId(actualizado.Identificacion);
            if (cliente != null)
            {
                cliente.NombreCompleto = actualizado.NombreCompleto;
                cliente.Provincia = actualizado.Provincia;
                cliente.Canton = actualizado.Canton;
                cliente.Distrito = actualizado.Distrito;
                cliente.DireccionExacta = actualizado.DireccionExacta;
                cliente.Telefono = actualizado.Telefono;
                cliente.Preferencia = actualizado.Preferencia;
            }
        }

        public void Eliminar(int id)
        {
            var cliente = BuscarPorId(id);
            if (cliente != null)
            {
                clientes.Remove(cliente);
            }
        }
    }
}
