using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBL.Core.Application.ViewModels.Author
{
    public class SaveAutorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe colocar el nombre del autor")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe colocar la URL de la imagen del autor")]
        public string ImageUrl { get; set; }

    }
}
