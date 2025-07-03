using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBL.Core.Application.ViewModels.Author
{
    public class AuthorViewModel
    {
        public int Id { get; set; } // 0 para nuevos
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public int LibrosQuantity { get; set; }
    }
}
