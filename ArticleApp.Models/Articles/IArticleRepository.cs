using Dul.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleApp.Models.Articles
{
    public interface IArticleRepository
    {
        Task<Article> AddArticleAsync(Article article);      //input
        Task<List<Article>> GetArticlesAsync();              //output

        Task<Article> GetArticleByIdAsync(int id);           //Detail

        Task<Article> EditArticleAsync(Article model);     // Edit

        Task DeleteArticleAsync(int id);                    //Delete

        Task<PagingResult<Article>> GetAllAsync(int pageindex, int pagesize);  //paging
    }
}
