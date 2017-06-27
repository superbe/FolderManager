namespace WebFolderManager.Core
{
	/// <summary>
	/// Интерфейс результата поиска.
	/// </summary>
	public interface ISearchResult
	{
		/// <summary>
		/// Полный путь к файлу.
		/// </summary>
		string Path { get; set; }

		/// <summary>
		/// Наименование файла.
		/// </summary>
		string FileName { get; set; }

		/// <summary>
		/// Размер файла.
		/// </summary>
		long Size { get; set; }

		/// <summary>
		/// Релевантность.
		/// </summary>
		double Relevance { get; set; }
	}
}