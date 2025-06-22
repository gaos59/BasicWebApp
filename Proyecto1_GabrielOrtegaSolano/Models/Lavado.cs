namespace Proyecto1_GabrielOrtegaSolano.Models
{
    public class Lavado
    {
        public int IdLavado { get; set; }
        public string PlacaVehiculo { get; set; }
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
        public const double IVA = 0.13;

        public enum EstadoLavado
        {
            EnProceso,
            Facturado,
            Agendado
        }
        public EstadoLavado Estado { get; set; }
    }
}
