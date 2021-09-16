using System;
using System.Collections.Generic;

namespace Inventario01.Models
{
    public partial class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int ModeloId { get; set; }

        public virtual Modelo Modelo { get; set; }
    }
}
