using SGBL.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBL.Core.Domain.Entities
{
    public class Libro : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string? Descrition { get; set; }
        public string ImageUrl { get; set; }
        public int AuthorId { get; set; }

        public int GeneroId { get; set; }



        //Navigation Property
        public Author? Author { get; set; }

        public Genero? Genero { get; set; }

    }
}
