using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace WebFolderManager.Core
{
	/// <summary>
	/// Управление поисковой машининой.
	/// </summary>
	public class SearchEngineManager
	{
		// Контейнер для плагинов.
		private CompositionContainer _container;

		// Поисковая машина.
		[Import(typeof(ISearchEngine))]
		public ISearchEngine searchEngine;

		/// <summary>
		/// Конструктор.
		/// </summary>
		public SearchEngineManager()
		{
			// Создаем сводный каталог, объединяющий несколько каталогов и заполняем его.
			try
			{
				var catalog = new AggregateCatalog();
				catalog.Catalogs.Add(new AssemblyCatalog(typeof(SearchEngineManager).Assembly));
				catalog.Catalogs.Add(new DirectoryCatalog("PlugIn"));
				_container = new CompositionContainer(catalog);
				_container.ComposeParts(this);
			}
			catch (CompositionException e)
			{
				throw new Exception("Ошибка поиска", e);
			}
		}
	}
}