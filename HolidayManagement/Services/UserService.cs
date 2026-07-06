using HolidayManagement.Database;
using HolidayManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HolidayManagement.Services
{
    public class UserService : Interfaces.IModelService<User>
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context) { 
            _context = context;
        }
        public async Task Create(User model)
        {
            _context.Users.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            User u = _context.Users.Single(x => x.Id == id);
            _context.Users.Remove(u);
            await _context.SaveChangesAsync();
        }

        public async Task<User> Get(Guid id)
        {
            return _context.Users.Single(x => x.Id == id);
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task Update(User model, Guid id)
        {
            User u = _context.Users.Single(y => y.Id == id);
            u.Username = model.Username;
            u.Password = model.Password;
            u.RoleId = model.RoleId;
            await _context.SaveChangesAsync();
        }
    }
}
