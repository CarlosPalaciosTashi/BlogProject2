using BlogProject2.Core;
using BlogProject2.Data.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject2.Web.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class CategoriesController : Controller
    {

        private readonly IWorkUnit _workUnit;

        public CategoriesController(IWorkUnit workUnit)
        {

            _workUnit = workUnit;
        }

        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid){
                _workUnit.Category.Add(category);
                _workUnit.Save();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Category category = new Category();
            category = _workUnit.Category.Get(id);
            if (category == null){

                return NotFound();
            }

            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid){
                _workUnit.Category.Update(category);
                _workUnit.Save();
                return RedirectToAction("Index");
            }

            return View(category);
        }




        // API REGION //

        [HttpGet]
        public IActionResult GetAll()
        {

            return Json(new { data = _workUnit.Category.GetAll() });
        }


        [HttpDelete]
        public IActionResult Delete(int id){

            var objectFromDb = _workUnit.Category.Get(id);

            if (objectFromDb == null ){
                
                return Json(new { success = false, message = "Error deleting category"});
            } 

            _workUnit.Category.Remove(objectFromDb);
            _workUnit.Save();

            return Json(new { success = true, message = "Category deleted"});
            
        }
    }
}