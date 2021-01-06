using sokolenko08DN.Models;
using Microsoft.AspNetCore.Mvc;

namespace sokolenko08DN.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {

        public HomeController(IStudentRepository studItems)
        {
            StudItems = studItems;
        }

        public IStudentRepository StudItems { get; set; }

        public IActionResult Index()
        {
            return View(StudItems.GetAll());
        }

        [HttpGet("{id}", Name = "GetStud")]
        public IActionResult GetById(long id)
        {
            var item = StudItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

    }
}
