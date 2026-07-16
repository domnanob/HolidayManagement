using HolidayManagement.Database;
using HolidayManagement.Models;
using HolidayManagement.Services.Abstracts;
using HolidayManagement.Services.Interfaces;

namespace HolidayManagement.Services
{
    public class CenterService(AppDbContext context) : ModelServiceBase<Center>(context), IModelService<Center>
    {
    }
}
