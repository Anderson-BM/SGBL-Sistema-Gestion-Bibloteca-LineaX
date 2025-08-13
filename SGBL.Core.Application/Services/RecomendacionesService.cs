using SGBL.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//namespace SGBL.Core.Application.Services
//{
//    public class RecomendacionesService
//    {
//        private readonly ApplicationContext _context;

//        public RecomendacionesService(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public List<Libro> ObtenerPorHistorial(string usuarioId)
//        {
//            var generosLeidos = _context.HistorialLectura
//                .Where(h => h.UsuarioId == usuarioId)
//                .Select(h => h.Libro.Genero)
//                .Distinct()
//                .ToList();

//            return _context.Libros
//                .Where(l => generosLeidos.Contains(l.Genero))
//                .OrderByDescending(l => l.Popularidad)
//                .Take(10)
//                .AsNoTracking()
//                .ToList();
//        }

//        public List<Libro> ObtenerPorPopularidad()
//        {
//            return _context.Libros
//                .OrderByDescending(l => l.Popularidad)
//                .Take(10)
//                .AsNoTracking()
//                .ToList();
//        }
//}
//}
