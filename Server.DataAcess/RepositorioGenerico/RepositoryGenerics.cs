using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using Server.Business.DesafioColorado.InterfaceGenerica;
using Server.DataAcess.DesafioColorado.Config;
using System.Runtime.InteropServices;

namespace Server.DataAcess.DesafioColorado.RepositorioGenerico
{
    public class RepositoryGenerics<T> : IGeneric<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<AppDbContext> _optionsBuilder;


        public RepositoryGenerics()
        {
            _optionsBuilder = new DbContextOptions<AppDbContext>();
        }

        public async Task InsertAsync(T Objeto)
        {
            await using var data = new AppDbContext(_optionsBuilder);
            await data.Set<T>().AddAsync(Objeto);
            await data.SaveChangesAsync();
        }

        public async Task UpdateAsync(T objeto)
        {
            await using var data = new AppDbContext(_optionsBuilder);
            data.Set<T>().Update(objeto);
            await data.SaveChangesAsync();
        }

        public async Task DeleteAsync(T objeto)
        {
            await using var data = new AppDbContext(_optionsBuilder);
            data.Set<T>().Remove(objeto);
            await data.SaveChangesAsync();
        }

        public async Task<T> FindByIdAsync(int id)
        {
            await using var data = new AppDbContext(_optionsBuilder);
            return await data.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> FindAllAsync()
        {
            await using var data = new AppDbContext(_optionsBuilder);
            return await data.Set<T>().ToListAsync();
        }

        public Task<List<T>> FindAllWithFilterAsync(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }


        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);



        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
        #endregion
    }
}
