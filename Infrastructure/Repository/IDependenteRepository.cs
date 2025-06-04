using System.Collections.Generic;
using System.Threading.Tasks;
using ZAlert.Api.Domain.Entity;

namespace ZAlert.Api.Infrastructure.Repository;

public interface IDependenteRepository
{
    Task<Dependente?> GetByIdAsync(int id);
    Task<List<Dependente>> GetByUsuarioIdAsync(int usuarioId);
    Task<List<Dependente>> GetByTipoAsync(string tipo);
    Task AddAsync(Dependente dependente);
    Task SaveChangesAsync();
}