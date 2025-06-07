using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ZAlert.Api.Domain.Entity;
using ZAlert.Api.Infrastructure.Persistence;

namespace ZAlert.Api.Infrastructure.Repository
{
    public class DispositivoRepository : IDispositivoRepository
    {
        private readonly ZAlertContext _context;

        public DispositivoRepository(ZAlertContext context) => _context = context;

        public async Task<Dispositivo?> GetByIdAsync(int id) =>
            await _context.Dispositivos.Include(d => d.Dependente).FirstOrDefaultAsync(d => d.IdDisposit == id);

        public async Task<Dispositivo?> GetByDependenteIdAsync(int dependenteId) =>
            await _context.Dispositivos.Include(d => d.Dependente).FirstOrDefaultAsync(d => d.Dependente.IdDepen == dependenteId);

        public async Task<Dispositivo?> GetByTipoAsync(string tipo) =>
            await _context.Dispositivos.FirstOrDefaultAsync(d => d.TipoDisposit == tipo);

        public async Task AddAsync(Dispositivo dispositivo) => await _context.Dispositivos.AddAsync(dispositivo);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        public async Task DeleteAsync(Dispositivo dispositivo)
        {
            _context.Dispositivos.Remove(dispositivo);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Dispositivo>> GetAllAsync(int skip, int take) =>
            await _context.Dispositivos.Include(d => d.Dependente)
                                       .Skip(skip)
                                       .Take(take)
                                       .ToListAsync();
    }
}