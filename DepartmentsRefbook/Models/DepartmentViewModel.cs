using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentsRefbook.Models
{
    /// <summary>
    /// Модель представления департамента на странице справочника подразделений
    /// </summary>
    public class DepartmentViewModel
    {
        /// <summary>
        /// Идентификатор департамента
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название департамента
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Коллекция отделов департамента
        /// </summary>
        public IList<BranchViewModel>? Branches { get; set; }

        /// <summary>
        /// Версия записи в БД
        /// </summary>
        public string? RowVersion { get; set; }

        /// <summary>
        /// Идентификатор компании, которой принадлежит департамент
        /// </summary>
        public int CompanyId { get; set; }
    }
}
