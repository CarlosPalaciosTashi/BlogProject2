using BlogProject2.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogProject2.Data.Data.Repository.IRepository{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);

        IEnumerable<SelectListItem> GetCategoriesList();
    }
}