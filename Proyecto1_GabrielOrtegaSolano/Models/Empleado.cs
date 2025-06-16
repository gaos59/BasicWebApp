namespace Proyecto1_GabrielOrtegaSolano.Models
{
    public class Empleado
    {
        public int Cedula { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaIngreso { get; set; }
        public double SalarioPorDia { get; set; }
        public double DiasVacaciones { get; set; }
        public DateTime FechaRetiro { get; set; }
        public double MontoLiquidacion { get; set; }
    }
}
