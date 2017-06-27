namespace WebFolderManager.Core
{
	/// <summary>
	/// Интерфейс логики работы с определенным форматом файла.
	/// </summary>
	public interface IFormat
	{
		/// <summary>
		/// Загрузить содержание файла и выбрать текстовую составляющую.
		/// </summary>
		/// <param name="fileName">Полный путь к загружаемому файлу.</param>
		/// <returns>Текст загруженного файла.</returns>
		string LoadText(string fileName);

		/// <summary>
		/// Получить расширение файла.
		/// </summary>
		/// <returns>Расширение файла.</returns>
		string Extension();

		/// <summary>
		/// Получить маску для поиска файлов определенного формата.
		/// </summary>
		/// <returns>Маска для поиска файлов определенного формата.</returns>
		string Mask();
	}
}