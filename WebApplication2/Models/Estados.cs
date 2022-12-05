using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Estados
    {
        [Key]
        public int PkEstado { get; set; }
        public string Estado { get; set; }
        
        [ForeignKey("Ciudades")]
        public int FkCiudad { get; set; }
        public Ciudades Ciudades { get; set; }
    }
}
