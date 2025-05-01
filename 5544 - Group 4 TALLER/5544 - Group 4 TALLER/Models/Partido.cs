using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _5544___Group_4_TALLER.Models
{
    public class Partido
    {
        [Key]
        public int PartidoID { get; set; }

        public int Jugados { get; set; }
        public int Ganados { get; set; }
        public int Empatados { get; set; }
        public int Perdidos { get; set; }

        [NotMapped]
        public int PuntosTotales => (Ganados * 3) + Empatados;

        public int EquipoID { get; set; }

        [ForeignKey("EquipoID")]
        public Equipo Equipo { get; set; }
    }
}
