using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using TelerikMvcApp1.Models;

namespace TelerikMvcApp1.Controllers
{
    public class HomeController : Controller
    {
        private List<ThingViewModel> things = new List<ThingViewModel>();

        public HomeController()
        {
            this.things.Add(new ThingViewModel()
            {
                Id = 1,
                Description = "First Thing"
            });

            this.things.Add(new ThingViewModel()
            {
                Id = 2,
                Description = "Second Thing"
            });

            this.things.Add(new ThingViewModel()
            {
                Id = 3,
                Description = "Third Thing"
            });

            this.things.Add(new ThingViewModel()
            {
                Id = 4,
                Description = "Fourth Thing"
            });

            this.ViewBag.DefaultThing = this.things.FirstOrDefault();
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GridDemo()
        {
            return this.View();
        }

        public JsonResult GetStuff([DataSourceRequest] DataSourceRequest request)
        {
            List<StuffViewModel> someStuff = new List<StuffViewModel>();
            someStuff.Add(new StuffViewModel()
                {
                    StuffId = 1,
                    Description = "First Stuff",
                    Thing = this.things.Where(t => t.Id == 1).FirstOrDefault()
                });

            someStuff.Add(new StuffViewModel()
            {
                StuffId = 2,
                Description = "Second Stuff",
                Thing = this.things.Where(t => t.Id == 3).FirstOrDefault()
            });

            return this.Json(someStuff.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult SaveStuff([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<StuffViewModel> saveStuffs)
        {
            return this.Json(saveStuffs.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult CreateStuff([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<StuffViewModel> saveStuffs)
        {
            return this.Json(saveStuffs.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult DestroyStuff([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<StuffViewModel> saveStuffs)
        {
            return this.Json(saveStuffs.ToDataSourceResult(request, this.ModelState));
        }

        public JsonResult GetThings()
        {

            return this.Json(this.things, JsonRequestBehavior.AllowGet);
        }
    }
}
