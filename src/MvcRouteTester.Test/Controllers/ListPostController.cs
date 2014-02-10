using System.Collections.Generic;
using System.Web.Mvc;

namespace MvcRouteTester.Test.Controllers
{
	public class ListPostController : Controller
	{
		[HttpPost]
		public ActionResult Index(List<int> ints)
		{
			return new EmptyResult();
		}
	}
}
