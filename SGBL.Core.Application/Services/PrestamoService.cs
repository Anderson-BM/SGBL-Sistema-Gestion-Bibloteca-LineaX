using AutoMapper;
using SGBL.Core.Application.Enums;
using SGBL.Core.Application.Interfaces.Repositories;
using SGBL.Core.Application.Interfaces.Services;
using SGBL.Core.Application.ViewModels.Prestamo;
using SGBL.Core.Domain.Entities;
using SGBL.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBL.Core.Application.Services
{
    public class PrestamoService : GenericService<SavePrestamoViewModel, PrestamoViewModel, Prestamo>, IPrestamoService
    {
        private readonly IPrestamoRepository _repository;
        private readonly IMapper _mapper;

        public PrestamoService(IPrestamoRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AprobarPrestamoAsync(int id)
        {
            var prestamo = await _repository.GetByIdAsync(id);
            prestamo.Estado = EstadoPrestamo.Aprobado;
            prestamo.FechaPrestamo = DateTime.Now;
            prestamo.FechaDevolucion = DateTime.Now.AddDays(7);
            await _repository.UpdateAsync(prestamo, prestamo.Id);
        }

        public async Task RechazarPrestamoAsync(int id)
        {
            var prestamo = await _repository.GetByIdAsync(id);
            prestamo.Estado = EstadoPrestamo.Rechazado;
            await _repository.UpdateAsync(prestamo, prestamo.Id);
        }

        public async Task DevolverPrestamoAsync(int id)
        {
            var prestamo = await _repository.GetByIdAsync(id);
            prestamo.Estado = EstadoPrestamo.Devuelto;
            prestamo.FechaDevolucion = DateTime.Now;
            await _repository.UpdateAsync(prestamo, prestamo.Id);

        }
    }
}
