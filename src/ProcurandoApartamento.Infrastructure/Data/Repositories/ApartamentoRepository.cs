using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JHipsterNet.Core.Pagination;
using JHipsterNet.Core.Pagination.Extensions;
using ProcurandoApartamento.Domain;
using ProcurandoApartamento.Domain.Repositories.Interfaces;
using ProcurandoApartamento.Infrastructure.Data.Extensions;

namespace ProcurandoApartamento.Infrastructure.Data.Repositories
{
    public class ApartamentoRepository : GenericRepository<Apartamento, long>, IApartamentoRepository
    {
        private readonly IUnitOfWork _context;

        public ApartamentoRepository(IUnitOfWork context) : base(context)
        {
            _context = context;
        }

        public async Task<Apartamento> BuscaMelhorApartamento(string[] request) 
        {
            IQueryable<Apartamento> query = Obter();
            query = query.Where(a => a.ApartamentoDisponivel == true && a.EstabelecimentoExiste == true && request.Contains(a.Estabelecimento));
            return query.OrderByDescending(a => a.Quadra).FirstOrDefault();
        } 
    }
}
