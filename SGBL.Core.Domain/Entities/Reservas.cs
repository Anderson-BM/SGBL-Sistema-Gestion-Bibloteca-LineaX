using SGBL.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBL.Core.Domain.Entities
{
    public class Reservas : AuditableBaseEntity
    {
        public int Id { get; set; }

        public int LibroId { get; set; }
        public Libro Libro { get; set; }

        public string UsuarioId { get; set; }

        public DateTime FechaReserva { get; set; } = DateTime.Now;
        public bool Notificado { get; set; } = false;
        public string Estado { get; set; } = "Pendiente"; // o "Completada", "Cancelada"
    }
}
