using System;
using System.Collections.Generic;
using System.Linq;

namespace InternProject
{
	/// <summary>
	/// Интерфейс вывода строк
	/// </summary>
	public class Printer : IPrinter
	{
		/// <summary>
		/// Вывод строк и статистики их упоминаний
		/// </summary>
		/// <param name="strings">Строки и их упоминания</param>
		public void Print(IDictionary<string, int> strings)
		{
			int pageLimit = 20;
			int counter = 0;
			foreach (var element in strings.OrderBy(x => x.Value))
			{
				Console.WriteLine($"{element.Key} - {element.Value}");
				
				if (counter == pageLimit)
                {
					Console.WriteLine("Нажмите любую клавишу для отображения следующих результатов");
					Console.ReadKey();
					counter = 0;
				}
				else
                {
					counter++;
				}
			}
		}
	}
}