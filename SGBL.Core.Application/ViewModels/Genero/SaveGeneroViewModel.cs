using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBL.Core.Application.ViewModels.Genero
{
    public class SaveGeneroViewModel
    {
        public int Id { get; set; }  // null para crear, con valor para editar

        [Required(ErrorMessage = "El nombre del género es obligatorio")]

        public string Name { get; set; }

        public string ImageUrl { get; set; }

    }
}
