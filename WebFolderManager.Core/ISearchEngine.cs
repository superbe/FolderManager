using System.Collections.Generic;

namespace WebFolderManager.Core
{
	/// <summary>
	/// Интерфейс поисковой машины.
	/// </summary>
	public interface ISearchEngine
	{
		/// <summary>
		/// Найти файлы.
		/// </summary>
		/// <param name="args">Фильтры поиска.</param>
		/// <returns>Результат поиска.</returns>
		List<SearchResult> Search(ISearchArguments args);

        /// <summary>
        /// Событие нахождения документа.
        /// </summary>
        event DocumentFoundDelegate DocumentFound;
    }
}