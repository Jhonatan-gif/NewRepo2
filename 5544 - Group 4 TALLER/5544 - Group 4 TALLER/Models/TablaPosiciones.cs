using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _5544___Group_4_TALLER.Models
{
    public class TablaPosiciones
    {
        [Key]
        public int TablaID { get; set; }
        public int Puntos { get; set; }
        public int PartidosJugados { get; set; }
        public int DiferenciaGol { get; set; }
        public int PosicionActual { get; set; }

        // FK
        public int EquipoID { get; set; }
        [ForeignKey("EquipoID")]
        public Equipo Equipo { get; set; }
    }
}
