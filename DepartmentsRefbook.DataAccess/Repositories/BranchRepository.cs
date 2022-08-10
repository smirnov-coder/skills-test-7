using DepartmentsRefbook.DataAccess.General;
using DepartmentsRefbook.Domain.Entities;

namespace DepartmentsRefbook.DataAccess.Repositories
{
    /// <inheritdoc cref="IBranchRepository"/>
    public class BranchRepository : IBranchRepository
    {
        private readonly ApplicationDbContext _db;

        public BranchRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task AddBranchAsync(Branch branch)
        {
            _db.Branches.Add(branch);
            return _db.SaveChangesAsync();
        }

        public Task DeleteBranchAsync(Branch branch)
        {
            _db.Branches.Remove(branch);
            return _db.SaveChangesAsync();
        }

        public Task<Branch?> GetBranchByIdAsync(int id)
        {
            return _db.Branches.FindAsync(id).AsTask();
        }

        public async Task MoveBranchToDepartmentAsync(Branch branch, Department department, byte[] branchRowVersion)
        {
            branch.DepartmentId = department.Id;
            _db.Entry(branch).Property(nameof(Branch.RowVersion)).OriginalValue = branchRowVersion;
            _db.Branches.Update(branch);
            await _db.SaveChangesAsync();
        }
    }
}
