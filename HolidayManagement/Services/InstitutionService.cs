using HolidayManagement.Database;
using HolidayManagement.Models;
using HolidayManagement.Services.Abstracts;
using HolidayManagement.Services.Interfaces;

namespace HolidayManagement.Services
{
    public class InstitutionService(AppDbContext context) : ModelServiceBase<Institution>(context), IModelService<Institution>
    {
    }
}
