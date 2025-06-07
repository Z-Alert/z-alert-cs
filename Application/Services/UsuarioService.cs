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
	public class UsuarioService
	{
		private readonly IUsuarioRepository _usuarioRepository;

		public UsuarioService(IUsuarioRepository usuarioRepository)
		{
			_usuarioRepository = usuarioRepository;
		}

		public async Task<List<Usuario>> ListarAsync(int skip, int take)
		{
			return await _usuarioRepository.GetAllAsync(skip, take);
		}

		public async Task<Usuario> BuscarPorIdAsync(int id)
		{
			var usuario = await _usuarioRepository.GetByIdAsync(id);
			if (usuario == null)
			{
				throw new EntityNotFoundException("Usuário não encontrado");
			}
			return usuario;
		}

		public async Task<Usuario> CriarAsync(UsuarioDto dto)
		{
			var usuario = Usuario.Create(dto.NmUsu, dto.EmailUsu, dto.SenhaUsu, UserRole.USER);
			await _usuarioRepository.AddAsync(usuario);
			await _usuarioRepository.SaveChangesAsync();
			return usuario;
		}

		public async Task<Usuario> AtualizarAsync(int id, UsuarioDto dto)
		{
			var usuario = await BuscarPorIdAsync(id);
			usuario.SetNmUsu(dto.NmUsu);
			usuario.SetEmailUsu(dto.EmailUsu);
			usuario.SetSenhaUsu(dto.SenhaUsu);

			await _usuarioRepository.SaveChangesAsync();
			return usuario;
		}

		public async Task DeletarAsync(int id)
		{
			var usuario = await BuscarPorIdAsync(id);
			await _usuarioRepository.DeleteAsync(usuario);
			await _usuarioRepository.SaveChangesAsync();
		}
	}
}
