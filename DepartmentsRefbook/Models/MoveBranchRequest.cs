using System.ComponentModel.DataAnnotations;

namespace DepartmentsRefbook.Models
{
    /// <summary>
    /// Запрос на перемещение отдела в другой департамент
    /// </summary>
    public class MoveBranchRequest
    {
        /// <summary>
        /// Идентификатор отдела
        /// </summary>
        [Required]
        public int BranchId { get; set; }

        /// <summary>
        /// Идентификатор департамента
        /// </summary>
        [Required]
        public int DepartmentId { get; set; }

        /// <summary>
        /// Версия записи отдела в БД
        /// </summary>
        [Required]
        public string? BranchRowVersion { get; set; }
    }
}
