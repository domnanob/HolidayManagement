using HolidayManagement.Database;
using HolidayManagement.Models;
using HolidayManagement.Services.Abstracts;
using HolidayManagement.Services.Interfaces;

namespace HolidayManagement.Services
{
    public class UserInstitutionService(AppDbContext context) : ModelServiceBase<UserInstitution>(context), IModelService<UserInstitution>
    {
    }
}
