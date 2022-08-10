using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentsRefbook.Domain.Entities
{
    /// <summary>
    /// Сущность отдела
    /// </summary>
    public class Branch : BaseEntity
    {
        /// <summary>
        /// Название отдела
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Версия записи в БД
        /// </summary>
        public byte[]? RowVersion { get; set; }

        /// <summary>
        /// Идентификатор департамента, которому принадлежит отдел
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Департамент, которому принадлежит отдел
        /// </summary>
        public Department? Department { get; set; }
    }
}
