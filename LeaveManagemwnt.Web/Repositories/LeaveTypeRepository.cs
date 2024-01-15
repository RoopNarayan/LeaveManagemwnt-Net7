using LeaveManagemwnt.Web.Contracts;
using LeaveManagemwnt.Web.Data;

namespace LeaveManagemwnt.Web.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(ApplicationDbContext context ):base(context) { }

        
    }
}
