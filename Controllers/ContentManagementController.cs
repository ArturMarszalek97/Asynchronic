using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Threading;
using WebApplication1.Models;
using System.Diagnostics;

namespace WebApplication1.Controllers
{
    public class ContentManagementController : Controller
    {
        public ActionResult Start()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Index()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            ContentManagement service = new ContentManagement();
            var content = service.GetContent();
            var count = service.GetCount();
            var name = service.GetName();

            watch.Stop();
            ViewBag.WatchMilliseconds = watch.ElapsedMilliseconds;
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> IndexAsync()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            ContentManagement service = new ContentManagement();
            var contentTask = service.GetContentAsync();
            var countTask = service.GetCountAsync();
            var nameTask = service.GetNameAsync();

            var content = await contentTask;
            var count = await countTask;
            var name = await nameTask;
            watch.Stop();
            ViewBag.WatchMilliseconds = watch.ElapsedMilliseconds;
            return View();
        }
    }
}