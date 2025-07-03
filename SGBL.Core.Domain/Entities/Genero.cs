using SGBL.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBL.Core.Domain.Entities
{
    public class Genero : AuditableBaseEntity
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Libro>? Libro { get; set; }
    }
}
