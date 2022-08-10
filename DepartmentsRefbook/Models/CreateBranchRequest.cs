using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int DepartmentId { get; set; }

        /// <summary>
        /// Название отдела
        /// </summary>
        public string? BranchName { get; set; }
    }
}
