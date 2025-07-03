using SGBL.Core.Application.ViewModels.Author;
using SGBL.Core.Application.ViewModels.Genero;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBL.Core.Application.ViewModels.Libro
{
    public class SaveLibroViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe colocar el nombre del libro")]
        public string Name { get; set; }

        public string? Descrition { get; set; }

        [Required(ErrorMessage = "Debe colocar la URL de la imagen del libro")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un autor")]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un género")]
        public int GeneroId { get; set; }

        public List<AuthorViewModel>? Author { get; set; }
        public List<GeneroViewModel>? Genero { get; set; }
    }
}
