using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ZAlert.Api.Domain.Entity;
using ZAlert.Api.Infrastructure.Persistence;

namespace ZAlert.Api.Infrastructure.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ZAlertContext _context;

        public UsuarioRepository(ZAlertContext context) => _context = context;

        public async Task<Usuario?> GetByIdAsync(int id) =>
            await _context.Usuarios.Include(u => u.Dependentes).FirstOrDefaultAsync(u => u.IdUsu == id);

        public async Task<Usuario?> GetByEmailAsync(string email) =>
            await _context.Usuarios.FirstOrDefaultAsync(u => u.EmailUsu == email);

        public async Task<bool> ExistsByEmailAsync(string email) =>
            await _context.Usuarios.AnyAsync(u => u.EmailUsu == email);

        public async Task AddAsync(Usuario usuario) => await _context.Usuarios.AddAsync(usuario);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        public async Task DeleteAsync(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Usuario>> GetAllAsync(int skip, int take) =>
            await _context.Usuarios.Include(u => u.Dependentes)
                                   .Skip(skip)
                                   .Take(take)
                                   .ToListAsync();
    }
}