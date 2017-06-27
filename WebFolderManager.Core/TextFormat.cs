using System;
using System.ComponentModel.Composition;
using System.IO;

namespace WebFolderManager.Core
{
	/// <summary>
	/// Логика работы с текстовым файлом.
	/// </summary>
	[Export(typeof(IFormat))]
	[ExportMetadata("Format", ".txt")]
	public class TextFormat : IFormat
	{
		/// <summary>
		/// Получить расширение файла.
		/// </summary>
		/// <returns>Расширение файла.</returns>
		public string Extension()
		{
			return ".txt";
		}

		/// <summary>
		/// Загрузить содержание текстового файла.
		/// </summary>
		/// <param name="fileName">Полный путь к загружаемому файлу.</param>
		/// <returns>Текст загруженного файла.</returns>
		public string LoadText(string fileName)
		{
			FileInfo file = new FileInfo(fileName);
			if (file.Extension != Extension()) throw new Exception(string.Format("Загружаемый файл {0} не является текстовым файлом.", fileName));
			if (!file.Exists) throw new Exception(string.Format("Загружаемый файл {0} не существует.", fileName));
			return File.ReadAllText(file.FullName);
		}

		/// <summary>
		/// Получить маску для поиска текстовых файлов.
		/// </summary>
		/// <returns>Маска для текстовых файлов.</returns>
		public string Mask()
		{
			return "*.txt";
		}
	}
}