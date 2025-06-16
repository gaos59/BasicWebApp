namespace Proyecto1_GabrielOrtegaSolano.Models
{
    public class Lavado
    {
        public int IdLavado { get; set; }
        public int PlacaVehiculo { get; set; }
        public int IdCliente { get; set; }
        public int IdEmpleado { get; set; }
        public enum TipoLavado
        {
            Basico,
            Premium,
            Deluxe,
            Lajoya
        }
        public TipoLavado Tipo { get; set; }
        public double Precio { get; set; }
        public double IVA { get; set; }
        public enum EstadoLavado
        {
            EnProceso,
            Facturado,
            Agendado
        }
        public EstadoLavado Estado { get; set; }
    }
}
