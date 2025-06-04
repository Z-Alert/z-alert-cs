using System.Threading.Tasks;
using ZAlert.Api.Domain.Entity;

namespace ZAlert.Api.Infrastructure.Repository;

public interface IDispositivoRepository
{
    Task<Dispositivo?> GetByIdAsync(int id);
    Task<Dispositivo?> GetByDependenteIdAsync(int dependenteId);
    Task<Dispositivo?> GetByTipoAsync(string tipo);
    Task AddAsync(Dispositivo dispositivo);
    Task SaveChangesAsync();
}