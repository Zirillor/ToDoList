using Microsoft.AspNetCore.Mvc;

namespace TwToDo.Controllers
{
    public class TesteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult teste2()
        {
            return View();
        }
    }
    
}