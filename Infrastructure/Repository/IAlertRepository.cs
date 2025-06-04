using System.Collections.Generic;
using System.Threading.Tasks;
using ZAlert.Api.Domain.Entity;

namespace ZAlert.Api.Infrastructure.Repository;

public interface IAlertaRepository
{
	Task<Alerta?> GetByIdAsync(int id);
	Task<List<Alerta>> GetByDependenteIdAsync(int dependenteId);
	Task<List<Alerta>> GetByStatusAsync(string status);
	Task<long> CountByStatusAsync(string status);
	Task AddAsync(Alerta alerta);
	Task SaveChangesAsync();
}