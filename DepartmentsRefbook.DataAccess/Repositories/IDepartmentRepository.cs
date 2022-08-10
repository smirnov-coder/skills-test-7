using DepartmentsRefbook.Domain.Entities;

namespace DepartmentsRefbook.DataAccess.Repositories
{
    /// <summary>
    /// Хранилище данных о департаментах
    /// </summary>
    public interface IDepartmentRepository
    {
        /// <summary>
        /// Асинхронно извлекает из хранилища данные о департаменте по идентификатору департамента
        /// </summary>
        /// <param name="id">Идентификатор департамента</param>
        Task<Department?> GetDepartmentByIdAsync(int id);

        /// <summary>
        /// Асинхронно перемещает департамент в другую компанию
        /// </summary>
        /// <param name="department">Перемещаемый департамент</param>
        /// <param name="company">Целевая компания</param>
        /// <param name="departmentRowVersion">Версия записи в БД</param>
        Task MoveDepartmentToCompanyAsync(Department department, Company company, byte[] departmentRowVersion);

        /// <summary>
        /// Асинхронно удаляет департамент из хранилища
        /// </summary>
        /// <param name="department">Удаляемый департамент</param>
        Task DeleteDepartmentAsync(Department department);

        /// <summary>
        /// Асинхронно добавляет департамент в хранилище
        /// </summary>
        /// <param name="department">Добавляемый департамент</param>
        Task AddDepartmentAsync(Department department);
    }
}