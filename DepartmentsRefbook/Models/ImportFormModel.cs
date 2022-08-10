using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
