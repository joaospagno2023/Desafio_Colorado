using System.Linq.Expressions;

namespace Server.Business.DesafioColorado.InterfaceGenerica
{
    public interface IGeneric<T> where T : class
    {
        Task InsertAsync(T objeto);
        Task UpdateAsync(T Objeto);
        Task DeleteAsync(T Objeto);
        Task<T> FindByIdAsync(int Id);
        Task<List<T>> FindAllAsync();
        Task<List<T>> FindAllWithFilterAsync(Expression<Func<T, bool>> filter);

    }
}
