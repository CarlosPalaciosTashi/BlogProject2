using Microsoft.AspNetCore.Mvc;
using BlogProject2.Core;
using BlogProject2.Data.Data.Repository.IRepository;
using BlogProject2.Core.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BlogProject2.Web.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ArticlesController : Controller
    {

        private readonly IWorkUnit _workUnit;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ArticlesController(IWorkUnit workUnit, IWebHostEnvironment hostingEnvironment)
        {

            _workUnit = workUnit;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ArticleViewModel artVM = new ArticleViewModel()
            {

                Article = new BlogProject2.Core.Article(),
                CategoriesList = _workUnit.Category.GetCategoriesList()

            };

            return View(artVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ArticleViewModel artVM)
        {
            if (ModelState.IsValid)
            {
                string mainRoot = _hostingEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                if (artVM.Article.Id == 0 && files.Count() > 0)
                {

                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(mainRoot, @"Images/Articles");
                    var extension = Path.GetExtension(files[0].FileName);

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStreams);
                    }

                    artVM.Article.UrlImage = @"/Images/Articles/" + fileName + extension;
                    artVM.Article.CreationDate = DateTime.Now.ToString();

                    _workUnit.Article.Add(artVM.Article);
                    _workUnit.Save();

                    return RedirectToAction(nameof(Index));

                }
                else
                {

                    ModelState.AddModelError("Image", "Add file is obligatory");
                }

            }

            artVM.CategoriesList = _workUnit.Category.GetCategoriesList();
            return View(artVM);
        }


    [HttpGet]
    public IActionResult Edit(int id){

        ArticleViewModel artVM = new ArticleViewModel(){

            Article = new BlogProject2.Core.Article(),
            CategoriesList = _workUnit.Category.GetCategoriesList()
        };

        if(id != 0){

            artVM.Article = _workUnit.Article.Get(id);
        }

        return View(artVM);
    }

        

        // API REGION //

        [HttpGet]
        public IActionResult GetAll()
        {

            return Json(new { data = _workUnit.Article.GetAll(includeProperties: "Category") });
        }


    }
}