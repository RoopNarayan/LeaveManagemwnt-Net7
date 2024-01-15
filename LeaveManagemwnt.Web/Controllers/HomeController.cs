using LeaveManagemwnt.Web.Data;
using LeaveManagemwnt.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LeaveManagemwnt.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            var totalLeaveTypes = context.LeaveTypes.Count();
            ViewBag.totalLeaveTypes = totalLeaveTypes;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}