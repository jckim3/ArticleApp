// C:\Users\jckim\.nuget\packages\microsoft.entityframeworkcore.inmemory\7.0.0\ 설치

using ArticleApp.Models.Articles;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArticleApp.Models.Test
{
    [TestClass]
    public class ArticleRepositoryTest
    {
        [TestMethod]
        public async Task ArticleRepositoryAllMethodTest()
        {
            var options = new DbContextOptionsBuilder<ArticleAppDBContext>()
                .UseInMemoryDatabase(databaseName: "ArticleApp")
                .Options;

            // AddAsync() Method Test

            using (var context = new ArticleAppDBContext(options)) 
            {
                var repository = new ArticleRepository(context);
                var model = new Article { Title = "Initiate Aritlce" ,Created = DateTime.Now};
                await repository.AddArticleAsync(model);
                await context.SaveChangesAsync();
            }

            using (var context = new ArticleAppDBContext(options))
            {
                Assert.AreEqual(1, await context.Articles.CountAsync());
            }
        }
    }
}
