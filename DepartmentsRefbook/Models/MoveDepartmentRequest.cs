using System.ComponentModel.DataAnnotations;

namespace DepartmentsRefbook.Models
{
    /// <summary>
    /// Запрос на перемещение департамента в другую компанию
    /// </summary>
    public class MoveDepartmentRequest
    {
        /// <summary>
        /// Идентфикатор департамента
        /// </summary>
        [Required]
        public int DepartmentId { get; set; }

        /// <summary>
        /// Версия записи департамента в БД
        /// </summary>
        [Required]
        public string? DepartmentRowVersion { get; set; }

        /// <summary>
        /// Идентификатор компании
        /// </summary>
        [Required]
        public int CompanyId { get; set; }
    }
}
