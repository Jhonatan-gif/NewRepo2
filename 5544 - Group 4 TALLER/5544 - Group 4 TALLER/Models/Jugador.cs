using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _5544___Group_4_TALLER.Models
{
    public class Jugador
    {
        [Key]
        public int JugadorID { get; set; }

        [Required]
        public string Nombre { get; set; }

        public int NumeroCamiseta { get; set; }
        public int Goles { get; set; }
        public int Asistencias { get; set; }
        public decimal Sueldo { get; set; }
        public string Nacionalidad { get; set; }

        public int EquipoID { get; set; }

        [ForeignKey("EquipoID")]
        public Equipo Equipo { get; set; }
    }
}
