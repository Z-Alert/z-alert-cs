using ZAlert.Api.Application.DTOs;
using ZAlert.Api.Domain.Entity;
using ZAlert.Api.Infrastructure.Repository;
using ZAlert.Api.Domain.Exceptions;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ZAlert.Api.Application.Services
{
    public class LocalizacaoService
    {
        private readonly ILocalizacaoRepository _localizacaoRepository;
        private readonly IDependenteRepository _dependenteRepository;

        public LocalizacaoService(ILocalizacaoRepository localizacaoRepository, IDependenteRepository dependenteRepository)
        {
            _localizacaoRepository = localizacaoRepository;
            _dependenteRepository = dependenteRepository;
        }

        public async Task<List<Localizacao>> ListarAsync(int skip, int take)
        {
            return await _localizacaoRepository.GetAllAsync(skip, take);
        }

        public async Task<Localizacao> BuscarPorIdAsync(int id)
        {
            var localizacao = await _localizacaoRepository.GetByIdAsync(id);
            if (localizacao == null)
            {
                throw new EntityNotFoundException("Localização não encontrada");
            }
            return localizacao;
        }

        public async Task<Localizacao> CriarAsync(LocalizacaoDto dto)
        {
            var dependente = await _dependenteRepository.GetByIdAsync(dto.DependenteId);
            if (dependente == null)
            {
                throw new EntityNotFoundException("Dependente não encontrado");
            }

            var localizacao = Localizacao.Create(dto.LatLocali, dto.LngLocali, DateTime.Now, dependente);
            await _localizacaoRepository.AddAsync(localizacao);
            await _localizacaoRepository.SaveChangesAsync();
            return localizacao;
        }

        public async Task<Localizacao> AtualizarAsync(int id, LocalizacaoDto dto)
        {
            var localizacao = await BuscarPorIdAsync(id);
            var dependente = await _dependenteRepository.GetByIdAsync(dto.DependenteId);
            if (dependente == null)
            {
                throw new EntityNotFoundException("Dependente não encontrado");
            }

            localizacao.SetLatLocali(dto.LatLocali);
            localizacao.SetLngLocali(dto.LngLocali);
            localizacao.SetDependente(dependente);

            await _localizacaoRepository.SaveChangesAsync();
            return localizacao;
        }

        public async Task DeletarAsync(int id)
        {
            var localizacao = await BuscarPorIdAsync(id);
            await _localizacaoRepository.DeleteAsync(localizacao);
            await _localizacaoRepository.SaveChangesAsync();
        }
    }
}