using System.Xml.Serialization;

namespace DepartmentsRefbook.Models
{
    /// <summary>
    /// Модель представления компании в XML-файле
    /// </summary>
    [XmlRoot("Company")]
    public class CompanyModel
    {
        /// <summary>
        /// Названеи компании
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Список департаментов
        /// </summary>
        [XmlArray("DepartmentList"), XmlArrayItem("Department")]
        public List<DepartmentModel> Departments { get; set; } = new List<DepartmentModel>();
    }
}
