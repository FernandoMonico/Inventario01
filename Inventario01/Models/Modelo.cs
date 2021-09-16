using System;
using System.Collections.Generic;

namespace Inventario01.Models
{
    public partial class Modelo
    {
        public Modelo()
        {
            Producto = new HashSet<Producto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int MarcaId { get; set; }

        public virtual Marca Marca { get; set; }
        public virtual ICollection<Producto> Producto { get; set; }
    }
}
