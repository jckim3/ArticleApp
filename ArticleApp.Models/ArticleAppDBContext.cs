using ArticleApp.Models.Articles;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace ArticleApp.Models
{
    /// <summary>
    /// DBContext Class
    /// </summary>
    public class ArticleAppDBContext :DbContext
    {
        public ArticleAppDBContext()
        {
            //Emty
        }

        public ArticleAppDBContext(DbContextOptions <ArticleAppDBContext> options)
            : base(options)
        {
            //공식과 같은 코드
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 닷넷 프레임워크 기반에서 호출되는 코드 영역
            // app.config 또는 web.config의 연결문자열 사용
            if ( !optionsBuilder.IsConfigured)
            {
                string connectionstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                optionsBuilder.UseSqlServer(connectionstring);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder )
        {
            //제약조건
            modelBuilder.Entity<Article>().Property(m => m.Created).HasDefaultValueSql("GetData()");
        }

        // Article 관련 모든 테이블 참조
        public DbSet<Article> Articles { get; set; }

    }
}
