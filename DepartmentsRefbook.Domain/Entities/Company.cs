using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentsRefbook.Domain.Entities
{
    /// <summary>
    /// Сущность компании
    /// </summary>
    public class Company : BaseEntity
    {
        /// <summary>
        /// Название компании
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Коллекция департаментов компании
        /// </summary>
        public IList<Department> Departments { get; set; } = new List<Department>();
    }
}
