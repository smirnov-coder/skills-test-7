using AutoMapper;

namespace DepartmentsRefbook.General
{
    /// <summary>
    /// Конвертер строкового представления RowVersion в байтовое представление
    /// </summary>
    public class StringToByteArrayConverter : IValueConverter<string, byte[]>
    {
        public byte[] Convert(string sourceMember, ResolutionContext context)
        {
            return RowVersionHelper.Decode(sourceMember);
        }
    }
}
