using System;
using System.Xml;
using System.ComponentModel.Composition;
using System.IO;

namespace WebFolderManager.Core
{
	/// <summary>
	/// Логика работы с XML файлом.
	/// </summary>
	[Export(typeof(IFormat))]
	[ExportMetadata("Format", ".xml")]
	public class XMLFormat : IFormat
	{
		/// <summary>
		/// Получить расширение файла.
		/// </summary>
		/// <returns>Расширение файла.</returns>
		public string Extension()
		{
			return ".xml";
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
			XmlDocument document = new XmlDocument();
			document.Load(fileName);
			return document.InnerText;
		}

		/// <summary>
		/// Получить маску для поиска текстовых файлов.
		/// </summary>
		/// <returns>Маска для текстовых файлов.</returns>
		public string Mask()
		{
			return "*.xml";
		}
	}
}