using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Formatters;
using System.Web.Mvc;
using System.Web.Routing;

using MvcRouteTester.ApiRoute;
using MvcRouteTester.Test.Assertions;
using MvcRouteTester.Test.Controllers;

using NUnit.Framework;

namespace MvcRouteTester.Test.WebRoute
{
	[TestFixture]
	public class ListPostControllerTests
	{
		private RouteCollection routes;

		[SetUp]
		public void MakeRouteTable()
		{
			RouteAssert.UseAssertEngine(new NunitAssertEngine());

			routes = new RouteCollection();
			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}",
				defaults: new { controller = "Home", action = "Index" });
		}

		[TearDown]
		public void TearDown()
		{
			RouteAssert.UseAssertEngine(new NunitAssertEngine());
		}

		[Test]
		public void HasIndexRoute()
		{
			RouteAssert.HasRoute(routes, "/ListPost/Index");
		}

		[Test]
		public void HasPostRoute()
		{
			RouteAssert.HasRoute(routes, "/ListPost/Index", HttpMethod.Post);
		}

		[Test]
		public void HasPostRouteWithValues()
		{
			var expections = new Dictionary<string, string>
				{
					{ "ints", "1,2,3" }
				};
			RouteAssert.HasRoute(routes, "/ListPost/Index", HttpMethod.Post, expections);
		}

		[Test]
		public void HasPostRouteWithFluentValues()
		{
			var ints = new List<int> {1, 2, 3};

			routes
				.ShouldMap("/ListPost/Index")
				.WithFormUrlBody("ints=1&ints=2&ints=3")
				.To<ListPostController>(x => x.Index(ints));
		}

	}
}
