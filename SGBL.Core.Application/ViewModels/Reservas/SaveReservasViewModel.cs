using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBL.Core.Application.ViewModels.Reservas
{
    public class SaveReservasViewModel
    {
        [Required(ErrorMessage = "Debe seleccionar un libro")]
        [Display(Name = "Libro")]
        public int LibroId { get; set; }

        // Este campo será automáticamente llenado desde el contexto del usuario logueado
        [Required(ErrorMessage = "Debe haber un usuario autenticado")]
        public string UsuarioId { get; set; }

        [Display(Name = "Fecha de Reserva")]
        public DateTime FechaReserva { get; set; } = DateTime.Now;

        [Display(Name = "¿Notificado?")]
        public bool Notificado { get; set; } = false;

        [Required(ErrorMessage = "Debe indicar el estado de la reserva")]
        [Display(Name = "Estado de la Reserva")]
        public string Estado { get; set; } = "Pendiente";

        // Para mostrar el título del libro seleccionado (opcional, si es necesario para la vista)
        public string? LibroTitulo { get; set; }
    }
}
