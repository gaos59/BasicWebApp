using Microsoft.EntityFrameworkCore;
using ProyectoApiRest.Datos;
using ProyectoWebMVC.Models;
using System;

namespace ProyectoApiRest.Servicios
{
    public class ClienteService : IClienteService
    {
        private DbContexto _context;

        public ClienteService(DbContexto context)
        {
            _context = context;
        }

        public List<Cliente> ObtenerTodos()
        {
            return _context.Clientes.ToList();
        }

        public List<Cliente> Buscar(string filtro)
        {
            return _context.Clientes
                .Where(c =>
                    c.NombreCompleto.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                    c.Identificacion.ToString().Contains(filtro)
                )
                .ToList();
        }

        public Cliente BuscarPorId(int id)
        {
            return _context.Clientes.FirstOrDefault(c => c.Identificacion == id);
        }

        public void Crear(Cliente nuevo)
        {
            _context.Clientes.Add(nuevo);
            _context.SaveChanges();
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

                _context.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            var cliente = BuscarPorId(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
        }
    }
}
