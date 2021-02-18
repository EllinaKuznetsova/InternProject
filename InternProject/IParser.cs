using System.IO;
using System.Collections.Generic;
using System.Text;

namespace InternProject
{
    /// <summary>
    /// Интерфейс парсера
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Парсинг потока данных
        /// </summary>
        /// <param name="stream">Поток данных</param>
        /// <returns>Перечисление строк</returns>
        IEnumerable<string> Parse(Stream stream);
    }
}
