using System;

namespace DepartmentsRefbook.General
{
    /// <summary>
    /// Вспомогательный класс для работы с RowVersion
    /// </summary>
    public static class RowVersionHelper
    {
        /// <summary>
        /// Кодирует массив байтов RowVersion в строковое представление
        /// </summary>
        /// <param name="rowVersion">Массив байтов RowVersion, хранящийся в БД</param>
        public static string Encode(byte[] rowVersion) => Convert.ToBase64String(rowVersion);

        /// <summary>
        /// Декодирует строковое представление RowVersion в массив байтов
        /// </summary>
        /// <param name="rowVersion">Строковое представление RowVersion</param>
        public static byte[] Decode(string rowVersion) => Convert.FromBase64String(rowVersion);
    }
}
