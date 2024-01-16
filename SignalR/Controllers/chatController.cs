using Microsoft.AspNetCore.Mvc;

namespace SignalR.Controllers
{
    public class chatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
