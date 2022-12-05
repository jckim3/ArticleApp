using Dul.Board;
using Dul.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace ArticleApp.Models.Articles
{
    /// <summary>
    /// Repositoty implenet Class , Ado.net Demo, Entity Frame, CRUD operatin 진행
    /// Entity Frame 을 이번에는 사용하도록 한다. 
    /// </summary>
    public class ArticleRepository : IArticleRepository
    {
        ArticleAppDBContext _context;
        public ArticleRepository(ArticleAppDBContext context)
        {
            this._context = context;        
        }

        // Add 입역
        public async Task<Article> AddArticleAsync(Article model)
        {
            _context.Articles.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        //출력
        public Task<List<Article>> GetArticlesAsync()
        {
            return _context.Articles.OrderByDescending(a=>a.Id).ToListAsync();
        }

        //상세보기
        public async Task<Article> GetArticleByIdAsync(int id)
        {
            return await _context.Articles.Where(a => a.Id == id).SingleOrDefaultAsync();
            //return await _context.Articles.FindAsync(id);
        }

        // 페이징
        public async Task<PagingResult<Article>> GetAllAsync(int pageindex, int pagesize)
        {
            //페이징부터 가져오기
            var totalRecords = await _context.Articles.CountAsync();
            var articles = await _context.Articles
                .OrderByDescending(x => x.Id)
                .Skip(pageindex*pagesize)
                .Take(pagesize)
                .ToListAsync();
            return new PagingResult<Article>(articles, totalRecords);
        }
        public async Task<Article> EditArticleAsync(Article model)
        {
            _context.Entry(model).State= EntityState.Modified;
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task DeleteArticleAsync(int id)
        {
            //var model = await _context.Articles.FindAsync(id);
            var model = await _context.Articles.Where(m => m.Id == id).SingleOrDefaultAsync();
            if ( model != null )
            {
                _context.Articles.Remove(model);
                await _context.SaveChangesAsync();
            }
        }

    }
}
