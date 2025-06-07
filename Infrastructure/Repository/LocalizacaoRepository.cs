using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAlert.Api.Domain.Entity;
using ZAlert.Api.Infrastructure.Persistence;

namespace ZAlert.Api.Infrastructure.Repository
{
    public class LocalizacaoRepository : ILocalizacaoRepository
    {
        private readonly ZAlertContext _context;

        public LocalizacaoRepository(ZAlertContext context) => _context = context;

        public async Task<Localizacao?> GetByIdAsync(int id) =>
            await _context.Localizacoes.Include(l => l.Dependente).FirstOrDefaultAsync(l => l.IdLocali == id);

        public async Task<List<Localizacao>> GetByDependenteIdAsync(int dependenteId) =>
            await _context.Localizacoes.Where(l => l.Dependente.IdDepen == dependenteId).ToListAsync();

        public async Task<List<Localizacao>> GetRecentByDependenteIdAsync(int dependenteId, int count) =>
            await _context.Localizacoes
                .Where(l => l.Dependente.IdDepen == dependenteId)
                .OrderByDescending(l => l.DataHora)
                .Take(count)
                .ToListAsync();

        public async Task AddAsync(Localizacao localizacao) => await _context.Localizacoes.AddAsync(localizacao);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        public async Task DeleteAsync(Localizacao localizacao)
        {
            _context.Localizacoes.Remove(localizacao);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Localizacao>> GetAllAsync(int skip, int take) =>
            await _context.Localizacoes.Include(l => l.Dependente)
                                       .Skip(skip)
                                       .Take(take)
                                       .ToListAsync();
    }
}