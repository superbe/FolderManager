namespace WebFolderManager.Core
{
	/// <summary>
	/// Результат поиска.
	/// </summary>
	public class SearchResult : ISearchResult
	{
		/// <summary>
		/// Наименование файла.
		/// </summary>
		public string FileName { get; set; }

		/// <summary>
		/// Полный путь к файлу.
		/// </summary>
		public string Path { get; set; }

		/// <summary>
		/// Релевантность.
		/// </summary>
		public double Relevance { get; set; }

		/// <summary>
		/// Размер файла.
		/// </summary>
		public long Size { get; set; }
	}
}