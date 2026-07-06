using HolidayManagement.Database;
using HolidayManagement.Models;
using HolidayManagement.Services.Abstracts;

namespace HolidayManagement.Services
{
    public class UserService : ModelServiceBase<User>, Interfaces.IModelService<User>
    {
        public UserService(AppDbContext context):base(context) { 

        }
    }
}
