using System.Xml.Serialization;

namespace DepartmentsRefbook.Models
{
    /// <summary>
    /// Модель представления списка компаний (справочника) в XML-файле (корневой элемент)
    /// </summary>
    [XmlRoot("CompanyList")]
    public class CompanyListModel
    {
        /// <summary>
        /// Список компаний
        /// </summary>
        [XmlElement("Company")]
        public List<CompanyModel> Companies { get; set; } = new List<CompanyModel>();
    }
}
