using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentsRefbook.Models
{
    /// <summary>
    /// Модель представления компании на странице справочника подразделений
    /// </summary>
    public class CompanyViewModel
    {
        /// <summary>
        /// Идентификатор компании
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название компании
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Коллекция департаментов компании
        /// </summary>
        public IList<DepartmentViewModel>? Departments { get; set; }

    }
}
