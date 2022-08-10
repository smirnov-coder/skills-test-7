using System.Xml.Serialization;

namespace DepartmentsRefbook.Models
{
    /// <summary>
    /// Модель представления отдела в XML-файле
    /// </summary>
    [XmlRoot("Branch")]
    public class BranchModel
    {
        /// <summary>
        /// Название отдела
        /// </summary>
        public string? Name { get; set; }
    }
}
