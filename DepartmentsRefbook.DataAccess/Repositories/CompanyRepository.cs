using DepartmentsRefbook.DataAccess.General;
using DepartmentsRefbook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DepartmentsRefbook.DataAccess.Repositories
{
    /// <inheritdoc cref="ICompanyRepository"/>
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _db;

        public CompanyRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task<List<Company>> GetCompaniesAsync()
        {
            return _db.Companies
                .Include(c => c.Departments)
                .ThenInclude(d => d.Branches)
                .ToListAsync();
        }

        public Task AddCompaniesAsync(IEnumerable<Company> companies)
        {
            _db.Companies.AddRange(companies);
            return _db.SaveChangesAsync();
        }

        public Task<Company?> GetCompanyByIdAsync(int id)
        {
            return _db.Companies.FindAsync(id).AsTask();
        }
    }
}
