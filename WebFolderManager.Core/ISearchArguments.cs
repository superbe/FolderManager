using System;
using System.Collections.Generic;

namespace WebFolderManager.Core
{
	/// <summary>
	/// Интерфейс входных параметров поисковой машины.
	/// </summary>
	public interface ISearchArguments
	{
		/// <summary>
		/// Поисковый запрос.
		/// </summary>
		string Query { get; set; }

		/// <summary>
		/// Путь к папке поиска.
		/// </summary>
		string Path { get; set; }

		/// <summary>
		/// Искать только в текущей папке.
		/// </summary>
		bool OnlyCurrent { get; set; }

		/// <summary>
		/// Расширения файлов.
		/// </summary>
		List<string> Extensions { get; set; }

        /// <summary>
        /// Дата поиска.
        /// </summary>
        /// <remarks>
        /// TODO: Фильтрацию по диапазону можно сделать позже.
        /// </remarks>
        DateTime? Date { get; set; }

		/// <summary>
		/// Минимальный размер файла.
		/// </summary>
		int? MinSize { get; set; }

		/// <summary>
		/// Максимальный размер файла.
		/// </summary>
		int? MaxSize { get; set; }
	}
}