using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoWebMVC.Models
{
    public class LavadoViewModel
    {
        public Lavado Lavado { get; set; } = new Lavado();

        public List<SelectListItem> Vehiculos { get; set; } = new();
        public List<SelectListItem> Clientes { get; set; } = new();
        public List<SelectListItem> Empleados { get; set; } = new();
    }
}
