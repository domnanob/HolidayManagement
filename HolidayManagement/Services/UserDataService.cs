using HolidayManagement.Database;
using HolidayManagement.Models;
using HolidayManagement.Services.Abstracts;
using HolidayManagement.Services.Interfaces;

namespace HolidayManagement.Services
{
    public class UserDataService(AppDbContext context) : ModelServiceBase<UserData>(context), IModelService<UserData>
    {
    }
}
