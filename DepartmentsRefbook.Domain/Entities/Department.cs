using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentsRefbook.Domain.Entities
{
    /// <summary>
    /// Сущность департамента
    /// </summary>
    public class Department : BaseEntity
    {
        /// <summary>
        /// Название департамента
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Коллекция отделов департамента
        /// </summary>
        public IList<Branch>? Branches { get; set; }

        /// <summary>
        /// Версия записи в БД
        /// </summary>
        public byte[]? RowVersion { get; set; }

        /// <summary>
        /// Идентификатор компании, которой принадлежит департамент
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Компания, которой принадлежит департамент
        /// </summary>
        public Company? Company { get; set; }
    }
}
