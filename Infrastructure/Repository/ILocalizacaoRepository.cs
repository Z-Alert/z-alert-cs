using System.Collections.Generic;
using System.Threading.Tasks;
using ZAlert.Api.Domain.Entity;

namespace ZAlert.Api.Infrastructure.Repository;

public interface ILocalizacaoRepository
{
    Task<Localizacao?> GetByIdAsync(int id);
    Task<List<Localizacao>> GetByDependenteIdAsync(int dependenteId);
    Task<List<Localizacao>> GetRecentByDependenteIdAsync(int dependenteId, int count);
    Task AddAsync(Localizacao localizacao);
    Task SaveChangesAsync();

    Task DeleteAsync(Localizacao localizacao);
    Task<List<Localizacao>> GetAllAsync(int skip, int take);
}