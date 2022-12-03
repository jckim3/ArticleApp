using Dul.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ArticleApp.Models.Articles
{
    /// <summary>
    /// Artical Model Class : Articles table 1:1 mapping
    /// </summary>
    public class Article : AuditableBase

    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Title
        /// </summary>

        [Required]
        public string Title { get; set; }
    }
}
