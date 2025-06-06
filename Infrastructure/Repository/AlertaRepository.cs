using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZAlert.Api.Domain.Entity;
using ZAlert.Api.Infrastructure.Persistence;

namespace ZAlert.Api.Infrastructure.Repository
{
    public class AlertaRepository : IAlertaRepository
    {
        private readonly ZAlertContext _context;

        public AlertaRepository(ZAlertContext context) => _context = context;

        public async Task<Alerta?> GetByIdAsync(int id) =>
            await _context.Alertas.Include(a => a.Dependente).FirstOrDefaultAsync(a => a.IdAlerta == id);

        public async Task<List<Alerta>> GetByDependenteIdAsync(int dependenteId) =>
            await _context.Alertas.Where(a => a.Dependente.IdDepen == dependenteId).ToListAsync();

        public async Task<List<Alerta>> GetByStatusAsync(string status) =>
            await _context.Alertas.Where(a => a.SttsAlerta == status).ToListAsync();

        public async Task<long> CountByStatusAsync(string status) =>
            await _context.Alertas.LongCountAsync(a => a.SttsAlerta == status);

        public async Task AddAsync(Alerta alerta) => await _context.Alertas.AddAsync(alerta);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        public async Task DeleteAsync(Alerta alerta)
        {
            _context.Alertas.Remove(alerta);
            await _context.SaveChangesAsync();
        }
    }
}