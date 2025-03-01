using BlogProject2.Core;
using BlogProject2.Data.Data.Repository.IRepository;

namespace BlogProject2.Data.Data.Repository{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        private readonly ApplicationDbContext _db;

        public ArticleRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }

        public void Update(Article article)
        {
            var dbElement = _db.Article.FirstOrDefault(s => s.Id == article.Id);
            dbElement.Name = article.Name;
            dbElement.Description = article.Description;
            dbElement.UrlImage = article.UrlImage;
            dbElement.CategoryId = article.CategoryId;

           // _db.SaveChanges();
        }
    }


}