namespace BlogProject2.Data.Data.Repository.IRepository{

    public interface IWorkUnit : IDisposable{

        ICategoryRepository Category { get; }
        IArticleRepository Article { get; }

        void Save();

    }
}