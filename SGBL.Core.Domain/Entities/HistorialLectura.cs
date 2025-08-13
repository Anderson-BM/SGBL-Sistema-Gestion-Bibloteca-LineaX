using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBL.Core.Domain.Entities
{
    public class HistorialLectura
    {
        public int Id { get; set; }
        public string UsuarioId { get; set; }
        public User Usuario { get; set; }
        public int LibroId { get; set; }
        public Libro Libro { get; set; }
        public DateTime FechaLectura { get; set; }
        public bool MeInteresa { get; set; }

    }
}
