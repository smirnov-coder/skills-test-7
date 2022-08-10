using System.ComponentModel.DataAnnotations;

namespace DepartmentsRefbook.Models
{
    /// <summary>
    /// Модель данных формы импорта справочника из XML-файла
    /// </summary>
    public class ImportFormModel
    {
        [Required]
        public IFormFile? File { get; set; }
    }
}
