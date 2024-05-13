using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Server.Business.DesafioColorado.InterfaceGenerica
{
    public interface IPagination<T> where T : class
    {
        Task<List<T>> GetAllPaginatedAsync(int page = 1);

        Task<List<T>> GetAllPaginatedWithFilterAsync(Expression<Func<T, bool>> filter, int page = 1);

        Task<int> TotalItemsAsync();
        Task<int> TotalItemsWithFilterAsync(Expression<Func<T, bool>> filter);
    }
}
