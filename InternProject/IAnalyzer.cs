using System;
using System.Collections.Generic;
using System.Text;

namespace InternProject
{
    /// <summary>
    /// Интерфейс анализа строк
    /// </summary>
    public interface IAnalyzer
    {
        /// <summary>
        /// Анализ перечисления строк
        /// </summary>
        /// <param name="strings">Перечисление строк</param>
        /// <returns>Словарь строк и их количества упоминаний</returns>
        IDictionary<string, int> Analyze(IEnumerable<string> strings);
    }
}
