using Microsoft.EntityFrameworkCore;
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

        public async Task AddAsync(Dependente dependente) => await _context.Dependentes.AddAsync(dependente);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        public async Task DeleteAsync(Dependente dependente)
        {
            _context.Dependentes.Remove(dependente);
            await _context.SaveChangesAsync();
        }
    }
}