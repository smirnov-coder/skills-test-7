using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int CompanyId { get; set; }

        /// <summary>
        /// Название департамента
        /// </summary>
        public string? DepartmentName { get; set; }
    }
}
