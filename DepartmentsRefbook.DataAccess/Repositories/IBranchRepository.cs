using DepartmentsRefbook.Domain;
using DepartmentsRefbook.Domain.Entities;

namespace DepartmentsRefbook.DataAccess.Repositories
{
    /// <summary>
    /// Хранилище данных об отделах
    /// </summary>
    public interface IBranchRepository
    {
        /// <summary>
        /// Асинхронно перемещает отдел в другой департамент
        /// </summary>
        /// <param name="branch">Отдел</param>
        /// <param name="department">Целевой департамент</param>
        /// <param name="branchRowVersion">Версия записи в БД</param>
        Task MoveBranchToDepartmentAsync(Branch branch, Department department, byte[] branchRowVersion);

        /// <summary>
        /// Асинхронно извлекает данные отдела из хранилища по идентификатору отдела
        /// </summary>
        /// <param name="id">Идентификатор отдела</param>
        Task<Branch?> GetBranchByIdAsync(int id);

        /// <summary>
        /// Асинхронно удаляет отдел из хранилища
        /// </summary>
        /// <param name="branch">Удаляемый отдел</param>
        Task DeleteBranchAsync(Branch branch);

        /// <summary>
        /// Асинхронно добавляет отдел в хранилище
        /// </summary>
        /// <param name="branch">Добавляемый отдел</param>
        Task AddBranchAsync(Branch branch);
    }
}