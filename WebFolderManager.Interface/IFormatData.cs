namespace WebFolderManager.Core
{
	/// <summary>
	/// Интерфейс метаданных классов логики работы с определенным форматом файла.
	/// </summary>
	public interface IFormatData
	{
		/// <summary>
		/// Служебное наименование формата файла.
		/// </summary>
		string Format { get; }
	}
}