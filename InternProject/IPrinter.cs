using System;
using System.Collections.Generic;
using System.Text;

namespace InternProject
{
    /// <summary>
    /// Интерфейс вывода строк
    /// </summary>
    public interface IPrinter
    {
        /// <summary>
        /// Вывод строк и статистики их упоминаний
        /// </summary>
        /// <param name="strings">Строки и их упоминания</param>
        void Print(IDictionary<string, int> strings);
    }
}
