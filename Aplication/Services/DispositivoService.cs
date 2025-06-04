using ZAlert.Api.Application.DTOs;
using ZAlert.Api.Domain.Entity;
using ZAlert.Api.Infrastructure.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ZAlert.Api.Application.Services
{
    public class DispositivoService
    {
        private readonly IDispositivoRepository _dispositivoRepository;
        private readonly IDependenteRepository _dependenteRepository;

        public DispositivoService(IDispositivoRepository dispositivoRepository, IDependenteRepository dependenteRepository)
        {
            _dispositivoRepository = dispositivoRepository;
            _dependenteRepository = dependenteRepository;
        }

        public async Task<List<Dispositivo>> ListarAsync(int skip, int take)
        {
            return await _dispositivoRepository.GetAllAsync(skip, take);
        }

        public async Task<Dispositivo> BuscarPorIdAsync(int id)
        {
            var dispositivo = await _dispositivoRepository.GetByIdAsync(id);
            if (dispositivo == null)
            {
                throw new EntityNotFoundException("Dispositivo não encontrado");
            }
            return dispositivo;
        }

        public async Task<Dispositivo> CriarAsync(DispositivoDto dto)
        {
            var dependente = await _dependenteRepository.GetByIdAsync(dto.DependenteId);
            if (dependente == null)
            {
                throw new EntityNotFoundException("Dependente não encontrado");
            }

            var dispositivo = Dispositivo.Create(dto.TipoDisposit, dto.StatusDisposit, dependente);
            await _dispositivoRepository.AddAsync(dispositivo);
            await _dispositivoRepository.SaveChangesAsync();
            return dispositivo;
        }

        public async Task<Dispositivo> AtualizarAsync(int id, DispositivoDto dto)
        {
            var dispositivo = await BuscarPorIdAsync(id);
            var dependente = await _dependenteRepository.GetByIdAsync(dto.DependenteId);
            if (dependente == null)
            {
                throw new EntityNotFoundException("Dependente não encontrado");
            }

            dispositivo.SetTipoDisposit(dto.TipoDisposit);
            dispositivo.SetStatusDisposit(dto.StatusDisposit);
            dispositivo.SetDependente(dependente);

            await _dispositivoRepository.SaveChangesAsync();
            return dispositivo;
        }

        public async Task DeletarAsync(int id)
        {
            var dispositivo = await BuscarPorIdAsync(id);
            await _dispositivoRepository.DeleteAsync(dispositivo);
            await _dispositivoRepository.SaveChangesAsync();
        }
    }
}
