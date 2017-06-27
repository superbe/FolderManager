using Iveonik.Stemmers;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WebFolderManager.Core
{
	/// <summary>
	/// Поисковая машина. Реализует механизм выделения словоформ.
	/// </summary>
	/// <remarks>
	/// TODO: В дальнейшем можно реализовать построение индексов, тезаурусов 
	/// и поиск уже по индексам, что сэкономит время поиска.
	/// </remarks>
	[Export(typeof(ISearchEngine))]
	public class SearchEngine : ISearchEngine
	{
		// Механизмы загрузки, фильтрации и первичной обработки найденных файлов.
		[ImportMany]
		IEnumerable<Lazy<IFormat, IFormatData>> _formats;

		/// <summary>
		/// Событие нахождения документа.
		/// </summary>
		public event DocumentFoundDelegate DocumentFound;

		/// <summary>
		/// Обработчик события нахождения документа.
		/// </summary>
		/// <param name="e">Данные последнего найденного документа.</param>
		protected virtual void OnDocumentFound(DocumentFoundEventArgs e)
		{
			DocumentFound?.Invoke(this, e);
		}

		/// <summary>
		/// Найти файлы.
		/// </summary>
		/// <param name="args">Фильтры поиска.</param>
		/// <returns>Результат поиска.</returns>
		public List<SearchResult> Search(ISearchArguments args)
		{
			List<SearchResult> result = new List<SearchResult>();
			// Нашли все файлы по формату.
			DirectoryInfo folder = new DirectoryInfo(args.Path);
			List<FileInfo> files = new List<FileInfo>();
			foreach (string extension in args.Extensions)
				files.AddRange(folder.GetFiles(string.Format("*{0}", extension), args.OnlyCurrent ? SearchOption.TopDirectoryOnly : SearchOption.AllDirectories).ToList());
			foreach (FileInfo file in files)
			{
				foreach (Lazy<IFormat, IFormatData> item in _formats)
				{
					if (item.Metadata.Format.Equals(file.Extension))
					{
						string text = item.Value.LoadText(file.FullName);
						double relevance = GetRelevance(text, args.Query);
						// Фильтруем результат:
						if (
							// по релевантности;
							relevance > 0 &&
							// по дате;
							(args.Date == null || args.Date.Value.Date == file.CreationTime.Date || args.Date.Value.Date == file.LastWriteTime.Date) &&
							// по размеру.
							(args.MinSize == null || args.MinSize < file.Length) &&
							(args.MaxSize == null || args.MaxSize > file.Length))
						{
							DocumentFoundEventArgs foundArg = new DocumentFoundEventArgs
							{
								Result = new SearchResult
								{
									FileName = file.Name,
									Path = file.FullName,
									Size = file.Length,
									Relevance = relevance
								}
							};
							result.Add(foundArg.Result);
							// Запустили событие нахождения документа.
							OnDocumentFound(foundArg);
						}
					}
				}
			}
			return result;
		}

		// Вычислить вхождение искомой подстроки в текст.
		private double GetRelevance(string text, string query)
		{
			List<string> textWordsForm = GetWordsForm(text);
			List<string> queryWordsForm = GetWordsForm(query);
			List<string> result = textWordsForm.Intersect(queryWordsForm).ToList();
			return result.Count / queryWordsForm.Count;
		}

		// Получить словоформу.
		private List<string> GetWordsForm(string text)
		{
			List<string> result = new List<string>();
			IStemmer stemmer = new RussianStemmer();
			Match match = Regex.Match(text.ToLower(), @"([[^\wА-Яа-я]+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
			while (match.Success)
			{
				string stemmerResult = stemmer.Stem(match.Value);
				if (!result.Contains(stemmerResult))
					result.Add(stemmerResult);
				match = match.NextMatch();
			}
			return result;
		}
	}
}