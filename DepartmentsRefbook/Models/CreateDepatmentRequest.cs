using System.ComponentModel.DataAnnotations;

namespace DepartmentsRefbook.Models
{
    /// <summary>
    /// Запрос на создание департамента
    /// </summary>
    public class CreateDepatmentRequest
    {
        /// <summary>
        /// Идентификатор компании
        /// </summary>
        
        [Required]
        public int CompanyId { get; set; }

        /// <summary>
        /// Название департамента
        /// </summary>
        [Required]
        public string? DepartmentName { get; set; }
    }
}
