using BlogProject2.Core;

namespace BlogProject2.Data.Data.Repository.IRepository{
    public interface IArticleRepository : IRepository<Article>
    {
        void Update(Article article);
    }
}