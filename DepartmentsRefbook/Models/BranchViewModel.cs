using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentsRefbook.Models
{
    /// <summary>
    /// Модель представления отдела на странице справочника подразделений
    /// </summary>
    public class BranchViewModel
    {
        /// <summary>
        /// Идентификатор отдела
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Названеи отдела
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Версия записи в БД
        /// </summary>
        public string? RowVersion { get; set; }

        /// <summary>
        /// Идентификатор департамента, которому принадлежит отдел
        /// </summary>
        public int DepartmentId { get; set; }
    }
}
