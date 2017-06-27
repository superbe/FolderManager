using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebFolderManager.Web.Startup))]

namespace WebFolderManager.Web
{
	/// <summary>
	/// Запуск Owin приложения.
	/// </summary>
	public class Startup
	{
		/// <summary>
		/// Настройка запуска приложения.
		/// </summary>
		/// <param name="app">Объект приложения Owin.</param>
		public void Configuration(IAppBuilder app)
		{
			// Запустили SignalR.
			app.MapSignalR();
		}
	}
}