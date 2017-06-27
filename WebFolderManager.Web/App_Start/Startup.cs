using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebFolderManager.Web.App_Start.Startup))]

namespace WebFolderManager.Web.App_Start
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			app.MapSignalR();
		}
	}
}