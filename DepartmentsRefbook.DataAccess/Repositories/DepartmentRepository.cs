using DepartmentsRefbook.DataAccess.General;
using DepartmentsRefbook.Domain.Entities;

namespace DepartmentsRefbook.DataAccess.Repositories
{
    /// <inheritdoc cref="IDepartmentRepository"/>
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _db;

        public DepartmentRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task AddDepartmentAsync(Department department)
        {
            _db.Departments.Add(department);
            return _db.SaveChangesAsync();
        }

        public Task DeleteDepartmentAsync(Department department)
        {
            _db.Departments.Remove(department);
            return _db.SaveChangesAsync();
        }

        public Task<Department?> GetDepartmentByIdAsync(int id)
        {
            return _db.Departments.FindAsync(id).AsTask();
        }

        public async Task MoveDepartmentToCompanyAsync(Department department, Company company, byte[] departmentRowVersion)
        {
            department.CompanyId = company.Id;
            _db.Entry(department).Property(nameof(Department.RowVersion)).OriginalValue = departmentRowVersion;
            _db.Departments.Update(department);
            await _db.SaveChangesAsync();
        }
    }
}
