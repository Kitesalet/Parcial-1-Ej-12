using System.ComponentModel.DataAnnotations;

namespace EJ12.Models
{
    public class Empleado
    {

        [Required(ErrorMessage = "La propiedad {0} es obligatoria")]
        public int ID { get; set; }

        [Required(ErrorMessage = "La propiedad {0} es obligatoria")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La propiedad {0} es obligatoria")]
        public string Apellido { get; set; }

        [Range(11111111,99999999,ErrorMessage = "El {0} debe estar entre {1} y {2}")]
        public int Telefono { get; set; }



    }
}
