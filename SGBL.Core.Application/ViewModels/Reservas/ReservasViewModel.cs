using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBL.Core.Application.ViewModels.Reservas
{
    public class ReservasViewModel
    {
        public int LibroId { get; set; }          // <-- Agregar esta propiedad
        public string LibroTitulo { get; set; } // NUEVO
        public string UsuarioNombre { get; set; } // NUEVO

        public string UsuarioId { get; set; }     // <-- Agregar esta propiedad
        public int Id { get; set; }
        public string TituloLibro { get; set; }
        public string NombreUsuario { get; set; }
        public DateTime FechaReserva { get; set; }
        public string Estado { get; set; }
    }
}
