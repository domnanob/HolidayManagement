using HolidayManagement.Database;
using HolidayManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Reflection;

namespace HolidayManagement.Services
{
    public class UserDataService : Interfaces.IModelService<UserData>
    {
        private readonly AppDbContext _context;
        public UserDataService(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(UserData model)
        {
            _context.UserDatas.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            UserData ud = _context.UserDatas.Single(x => x.Id == id);
            _context.UserDatas.Remove(ud);
            await _context.SaveChangesAsync();
        }

        public async Task<UserData> Get(Guid id)
        {
            return _context.UserDatas.Single(x => x.Id == id);
        }

        public async Task<List<UserData>> GetAll()
        {
            return await _context.UserDatas.ToListAsync<UserData>();
        }

        public async Task Update(UserData model, Guid id)
        {
            throw new NotImplementedException();
        }

        /*public async Task Update(UserData model, Guid id)
        {
            UserData u = _context.UserDatas.Single(y => y.Id == id);

            Type userDataType = typeof(UserData);

            foreach (var property in userDataType.GetProperties()) {
                property.SetValue(u, userDataType.GetProperty(property.Name).GetValue(model));
            }

            await _context.SaveChangesAsync();
        }*/

    }
}
