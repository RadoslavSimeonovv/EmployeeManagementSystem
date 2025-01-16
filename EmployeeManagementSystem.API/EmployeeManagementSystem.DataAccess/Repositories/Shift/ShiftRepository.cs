using Microsoft.EntityFrameworkCore;
using CoreShift = EmployeeManagementSystem.DataAccess.Entities.Shift;

namespace EmployeeManagementSystem.DataAccess.Repositories.Shift
{
    public class ShiftRepository(IEmployeeManagementDbContext dbContext) : IShiftRepository
    {
        private readonly IEmployeeManagementDbContext _dbContext = dbContext;

        public async Task<CoreShift?> GetShiftById(Guid shiftId, CancellationToken cancellationToken)
        {
            var shift = await _dbContext.Shifts.SingleOrDefaultAsync(x => x.Id == shiftId)
                .ConfigureAwait(false);

            return shift == null ? null : shift;
        }

        public async Task<CoreShift> CreateShift(CoreShift shift, CancellationToken cancellationToken)
        {
            _dbContext.Shifts.Add(shift);
            await _dbContext.SaveAsync(cancellationToken).ConfigureAwait(false);

            return shift;
        }

        public async Task<CoreShift> UpdateShift(CoreShift shift, CancellationToken cancellationToken)
        {
            _dbContext.Shifts.Update(shift);
            await _dbContext.SaveAsync(cancellationToken).ConfigureAwait(false);

            return shift;
        }

        public async Task<bool> DeleteShift(Guid shiftId, CancellationToken cancellationToken)
        {
            var shift = await _dbContext.Shifts.SingleOrDefaultAsync(x => x.Id == shiftId, cancellationToken).ConfigureAwait(false);

            if (shift is null)
            {
                return false;
            }

            _dbContext.Shifts.Remove(shift);
            await _dbContext.SaveAsync(cancellationToken).ConfigureAwait(false);

            return true;
        }
    }
}
