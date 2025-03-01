using BlogProject2.Data.Data.Repository.IRepository;

namespace BlogProject2.Data.Data.Repository{

    public class WorkUnit : IWorkUnit{

        private readonly ApplicationDbContext _db;

        public WorkUnit(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Article = new ArticleRepository(_db);
            
        }

        public ICategoryRepository Category { get; private set; }
        public IArticleRepository Article { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
            
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}