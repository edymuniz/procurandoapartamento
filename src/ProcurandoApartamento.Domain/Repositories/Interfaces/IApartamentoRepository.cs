using System.Threading.Tasks;

namespace ProcurandoApartamento.Domain.Repositories.Interfaces
{
    public interface IApartamentoRepository : IGenericRepository<Apartamento, long>
    {
        Task<Apartamento> BuscaMelhorApartamento(string[] request);
    }
}
