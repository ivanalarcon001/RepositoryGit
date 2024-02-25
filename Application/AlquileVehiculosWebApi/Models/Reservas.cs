using System.ComponentModel.DataAnnotations.Schema;

namespace AlquileVehiculosWebApi.Models
{
    public class Reservas
    {
        public int Id { get; set; }
        public int Cliente_id { get; set; }
        public int Vehiculo_id { get; set; }
        public DateTime Fecha_inicio { get; set; }
        public DateTime Fecha_fin { get; set; }
        public string Estado { get; set; }

        // Establece la relación con la tabla Clientes
        [ForeignKey("Cliente_id")]
        public Clientes Cliente { get; set; }

        // Establece la relación con la tabla Vehiculos
        [ForeignKey("Vehiculo_id")]
        public Vehiculos Vehiculo { get; set; }

        // Establece la relación con la tabla Tarifas
        public int? Tarifa_id { get; set; }
        [ForeignKey("Tarifa_id")]
        public Tarifas Tarifa { get; set; }
    }
}
