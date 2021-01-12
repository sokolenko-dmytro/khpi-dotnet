using sokolenko08DN.Models;
using Microsoft.AspNetCore.Mvc;

namespace sokolenko08DN.Controllers
{
    [Route("")]
   
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

        //  [HttpGet("{id}", Name = "GetStud")]
        [HttpGet("GetStud")]
        [Route("GetStud/{id?}")]
        [Route("Home/GetStud/{id?}")]
        public IActionResult GetById(long? id)
        {

            if (!id.HasValue)
            {
                return View("StudenEdit", new Student());
            }
            var item = StudItems.Find(id.Value);
            return View("StudenEdit", item);

        }



        [HttpPost("SaveStud")]
        public IActionResult SaveStudent(Student item)
        {
            if (item.Id > 0)
                StudItems.Update(item);
            else
            {
                StudItems.Add(item);

            }

            StudItems.SaveDb();
            return RedirectToAction("");

        }
        [Route("RemoveStud/{id?}")]
        [Route("Home/RemoveStud/{id?}")]
        public IActionResult RemoveStudent(long id)
        {

            StudItems.Remove(id);
            StudItems.SaveDb();
            return RedirectToAction("");

        }

    }
}
