using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAlert.Api.Domain.Entity;
using ZAlert.Api.Infrastructure.Persistence;

namespace ZAlert.Api.Infrastructure.Repository
{
    public class DependenteRepository : IDependenteRepository
    {
        private readonly ZAlertContext _context;

        public DependenteRepository(ZAlertContext context) => _context = context;

        public async Task<Dependente?> GetByIdAsync(int id) =>
            await _context.Dependentes.Include(d => d.Usuario).FirstOrDefaultAsync(d => d.IdDepen == id);

        public async Task<List<Dependente>> GetByUsuarioIdAsync(int usuarioId) =>
            await _context.Dependentes.Where(d => d.Usuario.IdUsu == usuarioId).ToListAsync();

        public async Task<List<Dependente>> GetByTipoAsync(string tipo) =>
            await _context.Dependentes.Where(d => d.Tipo == tipo).ToListAsync();

        public async Task AddAsync(Dependente dependente) => await _context.Dependentes.AddAsync(dependente);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        public async Task DeleteAsync(Dependente dependente)
        {
            _context.Dependentes.Remove(dependente);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Dependente>> GetAllAsync(int skip, int take) =>
            await _context.Dependentes.Include(d => d.Usuario)
                                      .Skip(skip)
                                      .Take(take)
                                      .ToListAsync();
    }
}