using BlogProject2.Core;
using BlogProject2.Data.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogProject2.Data.Data.Repository{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetCategoriesList()
        {
            return _db.Category.Select(i => new SelectListItem(){

                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(Category category)
        {
            var dbElement = _db.Category.FirstOrDefault(s => s.Id == category.Id);
            dbElement.Name = category.Name;
            dbElement.Order = category.Order;

          //  _db.SaveChanges();
        }
    }


}