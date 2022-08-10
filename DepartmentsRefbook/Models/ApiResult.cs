using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentsRefbook.Models
{
    /// <summary>
    /// Результат выполнения запроса к API, для случаев, когда метод контроллера не возвращает полезные данные в ответе
    /// </summary>
    public class ApiResult
    {
        /// <summary>
        /// Сообщение об успешном выполнении операции
        /// </summary>
        public string? Success { get; set; }

        /// <summary>
        /// Сообщение о возникшей ошибке
        /// </summary>
        public string? Error { get; set; }

        /// <summary>
        /// Создаёт результат успешного выполнения операции
        /// </summary>
        /// <param name="message">Сообщение об успешном выполнении операции</param>
        public static ApiResult Ok(string message)
        {
            return new ApiResult { Success = message };
        }

        /// <summary>
        /// Создаёт результат о возникшей ошибке при выполнении операции
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        public static ApiResult Fail(string message)
        {
            return new ApiResult { Error = message };
        }
    }
}
