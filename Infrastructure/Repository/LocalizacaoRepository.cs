using Microsoft.EntityFrameworkCore;
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

        public async Task AddAsync(Localizacao localizacao) => await _context.Localizacoes.AddAsync(localizacao);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        public async Task DeleteAsync(Localizacao localizacao)
        {
            _context.Localizacoes.Remove(localizacao);
            await _context.SaveChangesAsync();
        }
    }
}