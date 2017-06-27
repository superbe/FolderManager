using Microsoft.AspNet.SignalR;
using System.Collections.Generic;
using WebFolderManager.Core;

namespace WebFolderManager.Web
{
	/// <summary>
	/// SignalR-хаб  поисковой машины.
	/// </summary>
	public class SearchEngineHub : Hub
	{
		// Количество найденных файлов.
		private int count;

		/// <summary>
		/// Найти файлы содержащие подстроку поиска и отфильтровать по полученных аттрибутам.
		/// </summary>
		/// <param name="value">Входная переменная содержащая подстроку поиска и параметры фильтрации.</param>
		public void Search(SearchArguments value)
		{
			count = 0;
			SearchEngineManager engineManager = new SearchEngineManager();
			engineManager.searchEngine.DocumentFound += SearchEngine_DocumentFound;
			List<SearchResult> result = engineManager.searchEngine.Search(value);
			Clients.Caller.setStateSearchResults("(поиск завершен)");
		}

		/// <summary>
		/// Обработчик события нахождения документа соответствующего строке запроса и установленным фильтрам.
		/// </summary>
		/// <param name="sender">Объект инициировавший событие.</param>
		/// <param name="e">Аргументы события.</param>
		private void SearchEngine_DocumentFound(object sender, DocumentFoundEventArgs e)
		{
			// Вернули клиенту данные о найденном файле.
			Clients.Caller.updateSearchResults(++count, e.Result.FileName, e.Result.Path, e.Result.Size);
		}
	}
}