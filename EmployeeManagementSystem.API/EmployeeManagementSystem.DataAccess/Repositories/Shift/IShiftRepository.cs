using CoreShift = EmployeeManagementSystem.DataAccess.Entities.Shift;

namespace EmployeeManagementSystem.DataAccess.Repositories.Shift
{
    public interface IShiftRepository
    {
        Task<CoreShift?> GetShiftById(Guid shiftId, CancellationToken cancellationToken);
        Task<CoreShift> CreateShift(CoreShift shift, CancellationToken cancellationToken);

        Task<CoreShift> UpdateShift(CoreShift shift, CancellationToken cancellationToken);

        Task<bool> DeleteShift(Guid shiftId, CancellationToken cancellationToken);
    }
}
