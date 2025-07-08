using SGBL.Core.Application.Enums;
using SGBL.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBL.Core.Application.ViewModels.Prestamo
{
    public class PrestamoViewModel
    {
        public int Id { get; set; }
        public string TituloLibro { get; set; }
        public string NombreUsuario { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime? FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public EstadoPrestamo Estado { get; set; }
    }

}
