using Microsoft.EntityFrameworkCore;
using University.Web.Data;
using University.Web.Models;

namespace University.Web.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly UniversityDbContext _db;
        private readonly DbSet<T> _entities;
        public BaseRepository(UniversityDbContext db)
        { 
            _db = db;
            _entities = _db.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deletedObj = await _entities.FindAsync(id);
            if (deletedObj != null)
            {
                _entities.Remove(deletedObj);
                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _entities.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        //public async Task<Course> AddAsync(Course obj)
        //{
        //    await _db.Courses.AddAsync(obj);
        //    await _db.SaveChangesAsync();
        //    return obj;
        //}

        //public async Task<bool> DeleteAsync(int id)
        //{

        //    var deletedObj = await _db.Courses.FindAsync(id);
        //    if(deletedObj != null)
        //    {
        //        _db.Courses.Remove(deletedObj);
        //        await _db.SaveChangesAsync();
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}

        //public async Task<IEnumerable<Course>> GetAllAsync()
        //{
        //    return await _db.Courses.ToListAsync();
        //}

        //public async Task<Course> GetAsync(int id)
        //{
        //    return await _db.Courses.FindAsync(id);
        //}

        //public async Task<Course> UpdateAsync(Course obj)
        //{
        //    _db.Courses.Update(obj);
        //    await _db.SaveChangesAsync();
        //    return obj;
        //}
    }
}
