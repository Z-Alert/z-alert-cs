using System.Threading.Tasks;
using ZAlert.Api.Domain.Entity;

namespace ZAlert.Api.Infrastructure.Repository;

public interface IUsuarioRepository
{
    Task<Usuario?> GetByIdAsync(int id);
    Task<Usuario?> GetByEmailAsync(string email);
    Task<bool> ExistsByEmailAsync(string email);
    Task AddAsync(Usuario usuario);
    Task SaveChangesAsync();
}