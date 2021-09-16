using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario01.Dto
{
    public class MarcaDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(100, ErrorMessage = "Maximo 100 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(100, ErrorMessage = "Maximo 250 caracteres")]
        public string Descripcion { get; set; }
    }
}
