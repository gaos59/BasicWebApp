using ProyectoWebMVC.Models;

namespace ProyectoWebMVC.Datos
{
    public class Clientes
    {
        private static List<Cliente> clientes = new List<Cliente>();

        public List<Cliente> ObtenerTodos()
        {
            if (!clientes.Any())
            {
                clientes.Add(new Cliente { Identificacion = 0, NombreCompleto = "Cliente Vacío" });
            }
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
            var cliente = clientes.FirstOrDefault(c => c.Identificacion == actualizado.Identificacion);
            if (cliente != null)
            {
                cliente.NombreCompleto = actualizado.NombreCompleto;
                cliente.DireccionExacta = actualizado.DireccionExacta;
                cliente.Provincia = actualizado.Provincia;
                cliente.Canton = actualizado.Canton;
                cliente.Distrito = actualizado.Distrito;
                cliente.Telefono = actualizado.Telefono;
                cliente.Preferencia = actualizado.Preferencia;
            }
        }

        public void Eliminar(int id)
        {
            var cliente = clientes.FirstOrDefault(c => c.Identificacion == id);
            if (cliente != null)
            {
                clientes.Remove(cliente);
            }
        }
    }
}
