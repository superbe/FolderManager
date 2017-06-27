using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WebFolderManager.Core;

namespace WebFolderManager.Web.Controllers
{
	public class SearchController : ApiController
	{
		public List<SearchResult> Find([FromBody]ISearchArguments value)
		{
			SearchEngineManager engineManager = new SearchEngineManager();
			List<SearchResult> result = (List<SearchResult>)engineManager.searchEngine.Search(value);
			return result;
		}
	}
}