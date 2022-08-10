using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int BranchId { get; set; }

        /// <summary>
        /// Идентификатор департамента
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Версия записи отдела в БД
        /// </summary>
        [Required]
        public string? BranchRowVersion { get; set; }
    }
}
