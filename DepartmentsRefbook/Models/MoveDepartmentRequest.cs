using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int DepartmentId { get; set; }

        /// <summary>
        /// Версия записи департамента в БД
        /// </summary>
        [Required]
        public string? DepartmentRowVersion { get; set; }

        /// <summary>
        /// Идентификатор компании
        /// </summary>
        public int CompanyId { get; set; }
    }
}
