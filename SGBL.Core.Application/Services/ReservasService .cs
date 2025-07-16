using AutoMapper;
using SGBL.Core.Application.Interfaces.Repositories;
using SGBL.Core.Application.Interfaces.Services;
using SGBL.Core.Application.ViewModels.Reservas;
using SGBL.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBL.Core.Application.Services
{
    public class ReservasService : IReservasService
    {
        private readonly IReservasRepository _reservaRepository;
        private readonly IMapper _mapper;

        public ReservasService(IReservasRepository reservaRepository, IMapper mapper)
        {
            _reservaRepository = reservaRepository;
            _mapper = mapper;
        }

        public async Task<List<ReservasViewModel>> GetAll()
        {
            var reservas = await _reservaRepository.GetReservasConLibrosYUsuarios();
            return _mapper.Map<List<ReservasViewModel>>(reservas);
        }

        public async Task Add(SaveReservasViewModel model)
        {
            if (!await PuedeReservar(model.LibroId, model.UsuarioId))
                throw new InvalidOperationException("No se puede reservar este libro.");

            var reserva = _mapper.Map<Reservas>(model);
            await _reservaRepository.AddAsync(reserva);
        }

        public async Task<bool> PuedeReservar(int libroId, string usuarioId)
        {
            var reservas = await _reservaRepository.GetAllAsync();
            return !reservas.Any(r => r.LibroId == libroId && r.UsuarioId == usuarioId && r.Estado == "Pendiente");
        }
    }
}