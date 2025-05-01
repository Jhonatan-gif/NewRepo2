using System.ComponentModel.DataAnnotations;

namespace _5544___Group_4_TALLER.Models
{
    public class Equipo
    {
        [Key]
        public int EquipoID { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string LogoURL { get; set; }
        public string Descripcion { get; set; }
        public decimal Presupuesto { get; set; }

        public ICollection<Jugador> Jugadores { get; set; }
        public ICollection<Partido> Partidos { get; set; }
        public TablaPosiciones TablaPosiciones { get; set; }
    }

}
    