using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Ciudades
    {
        [Key]
        public int PkCiudad { get; set; }
        public string Ciudad { get; set; }
    }
}
