using DepartmentsRefbook.Domain.Entities;

namespace DepartmentsRefbook.DataAccess.Repositories
{
    /// <summary>
    /// Хранилище данных о компаниях
    /// </summary>
    public interface ICompanyRepository
    {
        /// <summary>
        /// Асинхронное извлекает данные всех компаний из хранилища
        /// </summary>
        Task<List<Company>> GetCompaniesAsync();

        /// <summary>
        /// Асинхронно добавлет коллекцию даннх о компаниях в хранилище
        /// </summary>
        /// <param name="companies"></param>
        Task AddCompaniesAsync(IEnumerable<Company> companies);

        /// <summary>
        /// Асинхронно извлекает из хранилища данные о компании по идентификатору компании
        /// </summary>
        /// <param name="companyId">Идентификатор компании</param>
        Task<Company?> GetCompanyByIdAsync(int id);
    }
}