using HolidayManagement.Database;
using HolidayManagement.Models;
using HolidayManagement.Services.Abstracts;

namespace HolidayManagement.Services
{
    public class UserDataService : ModelServiceBase<UserData>, Interfaces.IModelService<UserData>
    {
        public UserDataService(AppDbContext context) : base(context) {
            
        }
    }
}
