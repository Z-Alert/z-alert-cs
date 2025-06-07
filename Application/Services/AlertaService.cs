using ZAlert.Api.Application.DTOs;
using ZAlert.Api.Domain.Entity;
using ZAlert.Api.Domain.Exceptions;
using ZAlert.Api.Infrastructure.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ZAlert.Api.Application.Services
{
    public class AlertaService
    {
        private readonly IAlertaRepository _alertaRepository;
        private readonly IDependenteRepository _dependenteRepository;

        public AlertaService(IAlertaRepository alertaRepository, IDependenteRepository dependenteRepository)
        {
            _alertaRepository = alertaRepository;
            _dependenteRepository = dependenteRepository;
        }

        public async Task<List<Alerta>> ListarAsync(int skip, int take)
        {
            return await _alertaRepository.GetAllAsync(skip, take);
        }

        public async Task<Alerta> BuscarPorIdAsync(int id)
        {
            var alerta = await _alertaRepository.GetByIdAsync(id);
            if (alerta == null)
            {
                throw new EntityNotFoundException("Alerta não encontrado");
            }
            return alerta;
        }

        public async Task<Alerta> CriarAsync(AlertaDto dto)
        {
            var dependente = await _dependenteRepository.GetByIdAsync(dto.DependenteId);
            if (dependente == null)
            {
                throw new EntityNotFoundException("Dependente não encontrado");
            }

            var alerta = Alerta.Create(DateTime.Now, dto.Localizacao, dto.SttsAlerta, dependente);
            await _alertaRepository.AddAsync(alerta);
            await _alertaRepository.SaveChangesAsync();
            return alerta;
        }

        public async Task<Alerta> AtualizarAsync(int id, AlertaDto dto)
        {
            var alerta = await BuscarPorIdAsync(id);
            var dependente = await _dependenteRepository.GetByIdAsync(dto.DependenteId);
            if (dependente == null)
            {
                throw new EntityNotFoundException("Dependente não encontrado");
            }

            alerta.SetLocalizacao(dto.Localizacao);
            alerta.SetSttsAlerta(dto.SttsAlerta);
            alerta.SetDependente(dependente);

            await _alertaRepository.SaveChangesAsync();
            return alerta;
        }

        public async Task DeletarAsync(int id)
        {
            var alerta = await BuscarPorIdAsync(id);
            await _alertaRepository.DeleteAsync(alerta);
            await _alertaRepository.SaveChangesAsync();
        }
    }
}
