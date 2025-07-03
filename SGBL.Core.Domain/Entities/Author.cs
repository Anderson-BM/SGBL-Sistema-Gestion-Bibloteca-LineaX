using SGBL.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBL.Core.Domain.Entities
{
    public class Author : AuditableBaseEntity
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }
        //navigation property 
        public ICollection<Libro>? Libro { get; set; }
    }
}
