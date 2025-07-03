using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBL.Core.Application.ViewModels.Libro
{
    public class LibroViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Descrition { get; set; }
        public string ImageUrl { get; set; }

        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

        public int GeneroId { get; set; }
        public string GeneroName { get; set; }
    }
}
