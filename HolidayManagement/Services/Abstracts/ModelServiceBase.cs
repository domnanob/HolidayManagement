using HolidayManagement.Database;
using HolidayManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HolidayManagement.Services.Abstracts
{
    public class ModelServiceBase<T> where T : class
    {
        private readonly AppDbContext _context;
        public ModelServiceBase(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(T model)
        {
            _context.Set<T>().Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {

            T u = await _context.Set<T>().SingleAsync(x => EF.Property<Guid>(x, "Id") == id);
            _context.Set<T>().Remove(u);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Get(Guid id)
        {
            return await _context.Set<T>().SingleAsync(x => EF.Property<Guid>(x, "Id") == id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task Update(T model, Guid id)
        {
            T u = await _context.Set<T>().SingleAsync(y => EF.Property<Guid>(y, "Id") == id);

            Type userDataType = typeof(T);

            foreach (var property in userDataType.GetProperties())
            {
                property.SetValue(u, userDataType.GetProperty(property.Name).GetValue(model));
            }

            await _context.SaveChangesAsync();
        }
    }
}
