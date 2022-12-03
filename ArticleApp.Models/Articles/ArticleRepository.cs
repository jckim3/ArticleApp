using Dul.Domain.Common;

namespace ArticleApp.Models.Articles
{
    /// <summary>
    /// Repositoty implenet Class , Ado.net Demo, Entity Frame, CRUD operatin 진행
    /// Entity Frame 을 이번에는 사용하도록 한다. 
    /// </summary>
    public class ArticleRepository : IArticleRepository
    {
        public Task<Article> AddArticleAsync(Article article)
        {
            throw new NotImplementedException();
        }

        public Task DeleteArticleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Article> EditArticleAsync(Article article)
        {
            throw new NotImplementedException();
        }

        public Task<PagingResult<Article>> GetAllAsync(int pageindex, int pagesize)
        {
            throw new NotImplementedException();
        }

        public Task<Article> GetArticleByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Article>> GetArticlesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
