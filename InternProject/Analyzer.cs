﻿using System;
using System.Collections.Generic;

namespace InternProject
{
	/// <summary>
	/// Анализ строк
	/// </summary>
	public class Analyzer : IAnalyzer
	{
		/// <summary>
		/// Анализ перечисления строк
		/// </summary>
		/// <param name="strings">Перечисление строк</param>
		/// <returns>Словарь строк и их количества упоминаний</returns>
		public IDictionary<string, int> Analyze(IEnumerable<string> strings)
		{
			if (strings is null)
			{
				string mess = $"Аргумент {nameof(strings)} равен null";
				Logger.Instance.Log(mess);
				throw new ArgumentNullException(mess);
			}

			var dict = new Dictionary<string, int>();

			foreach (var word in strings)
			{
				if (dict.ContainsKey(word))
				{
					dict[word] += 1;
				}
				else
				{
					dict[word] = 1;
				}
			}

			return dict;
		}
	}
}