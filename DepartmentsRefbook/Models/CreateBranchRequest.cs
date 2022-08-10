using System.ComponentModel.DataAnnotations;

namespace DepartmentsRefbook.Models
{
    /// <summary>
    /// Запрос на создание отдела
    /// </summary>
    public class CreateBranchRequest
    {
        /// <summary>
        /// Идентификатор департамента
        /// </summary>
        [Required]
        public int DepartmentId { get; set; }

        /// <summary>
        /// Название отдела
        /// </summary>
        [Required]
        public string? BranchName { get; set; }
    }
}
