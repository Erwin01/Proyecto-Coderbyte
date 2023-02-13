//using SIGACUtilitarios.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGACUtilitarios.Repositories.Implements
{
   
    //public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    //{
    //    private readonly SIGACDBContext _db;
    //    public GenericRepository(SIGACDBContext _db)
    //    {
    //        this._db = _db;
    //    }
    //    public async Task delete(int id)
    //    {
    //        var entity = await getById(id);
    //        if (entity == null)
    //        {
    //            throw new Exception("La entidad es null");
    //        }
    //        this._db.Set<TEntity>().Remove(entity);
    //        await this._db.SaveChangesAsync();
    //    }

    //    public async Task<IEnumerable<TEntity>> getAll()
    //    {
    //        return this._db.Set<TEntity>().ToList();
    //    }

    //    public async Task<TEntity> getById(int id)
    //    {
    //        return await this._db.Set<TEntity>().FindAsync(id);
    //    }

    //    public async Task<TEntity> insert(TEntity entity)
    //    {
    //        this._db.Set<TEntity>().Add(entity);
    //        await this._db.SaveChangesAsync();
    //        return entity;
    //    }

    //    public async Task<TEntity> update(TEntity entity)
    //    {
    //        this._db.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
    //        await this._db.SaveChangesAsync();
    //        return entity;
    //    }
    //}
}
