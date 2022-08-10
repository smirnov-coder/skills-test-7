using AutoMapper;

namespace DepartmentsRefbook.General
{
    /// <summary>
    /// Конвертер байтового представления RowVersion в строковое представление
    /// </summary>
    public class ByteArrayToStringConverter : IValueConverter<byte[], string>
    {
        public string Convert(byte[] sourceMember, ResolutionContext context)
        {
            return RowVersionHelper.Encode(sourceMember);
        }
    }
}
