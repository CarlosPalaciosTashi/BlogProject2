


using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogProject2.Core.ViewModels{

    public class ArticleViewModel{

        public Article Article { get; set; }

        public IEnumerable<SelectListItem> CategoriesList { get; set; }
    }

}