using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Pomodoro.UI.Controlers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddPomodoroType()
        {
            return PartialView("_AddPomodoroType");
        }

        [HttpGet]
        public IActionResult ShowSettings()
        {
            return PartialView("_Settings");
        }

        [HttpGet]
        public IActionResult ShowStatistics()
        {
            return PartialView("_Statistics");
        }

        [HttpGet]
        public IActionResult ShowHistory()
        {
            return PartialView("_PomodoroHistory");
        }
    }
}
