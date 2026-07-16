using HolidayManagement.Database;
using HolidayManagement.Models;
using HolidayManagement.Services.Abstracts;
using HolidayManagement.Services.Interfaces;

namespace HolidayManagement.Services
{
    public class RoleGroupService(AppDbContext context) : ModelServiceBase<RoleGroup>(context), IModelService<RoleGroup>
    {
    }
}
