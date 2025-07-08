using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBL.Core.Domain.Common;
using SGBL.Core.Domain.Enums;

namespace SGBL.Core.Domain.Entities
{
    public class Prestamo : AuditableBaseEntity
    {
        public int Id { get; set; }
        public int LibroId { get; set; }
        public int? UsuarioId { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime? FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public EstadoPrestamo Estado { get; set; }

        // Relaciones
        public Libro Libro { get; set; }
        public User? Usuario { get; set; }
    }
}
