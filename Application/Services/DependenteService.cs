using ZAlert.Api.Application.DTOs;
using ZAlert.Api.Domain.Entity;
using ZAlert.Api.Infrastructure.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ZAlert.Api.Application.Services
{
    public class DependenteService
    {
        private readonly IDependenteRepository _dependenteRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public DependenteService(IDependenteRepository dependenteRepository, IUsuarioRepository usuarioRepository)
        {
            _dependenteRepository = dependenteRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<List<Dependente>> ListarAsync(int skip, int take)
        {
            return await _dependenteRepository.GetAllAsync(skip, take);
        }

        public async Task<Dependente> BuscarPorIdAsync(int id)
        {
            var dependente = await _dependenteRepository.GetByIdAsync(id);
            if (dependente == null)
            {
                throw new EntityNotFoundException("Dependente não encontrado");
            }
            return dependente;
        }

        public async Task<Dependente> CriarAsync(DependenteDto dto)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(dto.UsuarioId);
            if (usuario == null)
            {
                throw new EntityNotFoundException("Usuário não encontrado");
            }

            var dependente = Dependente.Create(dto.NmDepen, dto.Tipo, dto.IdadeDepen ?? 0, usuario);
            await _dependenteRepository.AddAsync(dependente);
            await _dependenteRepository.SaveChangesAsync();
            return dependente;
        }

        public async Task<Dependente> AtualizarAsync(int id, DependenteDto dto)
        {
            var dependente = await BuscarPorIdAsync(id);
            var usuario = await _usuarioRepository.GetByIdAsync(dto.UsuarioId);
            if (usuario == null)
            {
                throw new EntityNotFoundException("Usuário não encontrado");
            }

            dependente.SetNmDepen(dto.NmDepen);
            dependente.SetTipo(dto.Tipo);
            dependente.SetIdadeDepen(dto.IdadeDepen ?? 0);
            dependente.SetUsuario(usuario);

            await _dependenteRepository.SaveChangesAsync();
            return dependente;
        }

        public async Task DeletarAsync(int id)
        {
            var dependente = await BuscarPorIdAsync(id);
            await _dependenteRepository.DeleteAsync(dependente);
            await _dependenteRepository.SaveChangesAsync();
        }
    }
}