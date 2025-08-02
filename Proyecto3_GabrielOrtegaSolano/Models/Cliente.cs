namespace ProyectoWebMVC.Models
{
    public class Cliente
    {
        public int Identificacion { get; set; }
        public string NombreCompleto { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string DireccionExacta { get; set; }
        public int Telefono { get; set; }
        public enum PreferenciaLavado
        {
            semanal,
            quincenal,
            mensual,
            otro
        }
        public PreferenciaLavado Preferencia { get; set; }
    }
}
