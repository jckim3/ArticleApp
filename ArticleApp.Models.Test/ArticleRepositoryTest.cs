// C:\Users\jckim\.nuget\packages\microsoft.entityframeworkcore.inmemory\7.0.0\ 설치
// C:\Users\jckim\.nuget\packages\microsoft.entityframeworkcore.sqlserver\7.0.0\ 설치
using ArticleApp.Models.Articles;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using System.Reflection.Metadata;

namespace ArticleApp.Models.Test
{
    [TestClass]
    public class ArticleRepositoryTest
    {
        [TestMethod]
        public async Task ArticleRepositoryAllMethodTest()
        {
            var options = new DbContextOptionsBuilder<ArticleAppDBContext>()
                //.UseInMemoryDatabase(databaseName: "ArticleApp")
                //.UseSqlServer("Data Source=JCDESKTOP\\SQLEXPRESS;Database=ArticleApp;Trusted_Connection=True;User ID=sa;Password=32355;MultipleActiveResultSets=true")
                //.UseSqlServer("Data Source=JCDESKTOP\\SQLEXPRESS;Persist Security Info=False;User ID=sa;password=32355;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False")
                .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Articles; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False")
                .Options;

            // AddAsync() Method Test

            using (var context = new ArticleAppDBContext(options)) 
            {
                var repository = new ArticleRepository(context);
                var model = new Article { Title = "Initiate Aritlce" ,Created = DateTime.Now};
                await repository.AddArticleAsync(model);
                await context.SaveChangesAsync();

                // Add second record
                model = new Article { Title = "2nd Aritlce", Created = DateTime.Now };
                await repository.AddArticleAsync(model);
                await context.SaveChangesAsync();
            }

            using (var context = new ArticleAppDBContext(options))
            {
                Assert.AreEqual(2, await context.Articles.CountAsync());
                var model = await context.Articles.Where(m=>m.Id==1).SingleOrDefaultAsync();
                Assert.AreEqual("Initiate Aritlce", model?.Title);
            }

            // GetAllSync() method Test
            using (var context = new ArticleAppDBContext(options))
            {
                var repository = new ArticleRepository(context);
                var model = new Article { Title = "3rd Aritlce", Created = DateTime.Now };
                await repository.AddArticleAsync(model);
                await context.SaveChangesAsync();
            }
            // 3개 들어가 있는거 구나. 
            using (var context = new ArticleAppDBContext(options))
            {
                var repository = new ArticleRepository(context);
                var models = await repository.GetArticlesAsync();
                Assert.AreEqual(3, models.Count);
            }

            // GetByID
            using (var context = new ArticleAppDBContext(options))
            {
                var repository = new ArticleRepository(context);
                var model = await repository.GetArticleByIdAsync(2);
                Assert.IsTrue(model?.Title.Contains("2nd"));
            }

            // Edit 
            using (var context = new ArticleAppDBContext(options))
            {
                var repository = new ArticleRepository(context);

                var model = await repository.GetArticleByIdAsync(2);
                model.Title = "2nd Busy Article";
                await repository.EditArticleAsync(model);
                await context.SaveChangesAsync();

                var model2 = await repository.GetArticleByIdAsync(2);
                Assert.IsTrue(model2?.Title.Contains("Busy"));
            }

            // Delete
            using (var context = new ArticleAppDBContext(options))
            {
                var repository = new ArticleRepository(context);
                await repository.DeleteArticleAsync(2);
                await context.SaveChangesAsync();

                var models = await repository.GetArticlesAsync();
                Assert.AreEqual(2, models.Count);
            }

        }
    }
}
