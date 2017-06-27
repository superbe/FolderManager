using System;
using System.Collections.Generic;

namespace WebFolderManager.Core
{
	/// <summary>
	/// Входные параметры поисковой машины.
	/// </summary>
	public class SearchArguments : ISearchArguments
	{
		/// <summary>
		/// Расширения файлов.
		/// </summary>
		public List<string> Extensions { get; set; }

		/// <summary>
		/// Искать только в текущей папке.
		/// </summary>
		public bool OnlyCurrent { get; set; }

		/// <summary>
		/// Путь к папке поиска.
		/// </summary>
		public string Path { get; set; }

		/// <summary>
		/// Поисковый запрос.
		/// </summary>
		public string Query { get; set; }

        /// <summary>
        /// Дата поиска.
        /// </summary>
        /// <remarks>
        /// TODO: Фильтрацию по диапазону можно сделать позже.
        /// </remarks>
        public DateTime? Date { get; set; }

		/// <summary>
		/// Минимальный размер файла.
		/// </summary>
		public int? MinSize { get; set; }

		/// <summary>
		/// Максимальный размер файла.
		/// </summary>
		public int? MaxSize { get; set; }

		/// <summary>
		/// Конструктор.
		/// </summary>
		public SearchArguments()
		{
			Extensions = new List<string>();
		}
	}
}