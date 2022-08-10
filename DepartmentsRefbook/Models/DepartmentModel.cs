using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace DepartmentsRefbook.Models
{
    /// <summary>
    /// Модель представления департамента в XML-файле
    /// </summary>
    [XmlRoot("Department")]
    public class DepartmentModel
    {
        /// <summary>
        /// Название департамента
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Список отделов
        /// </summary>
        [XmlArray("BranchList"), XmlArrayItem("Branch")]
        public List<BranchModel> Branches { get; set; } = new List<BranchModel>();
    }
}
