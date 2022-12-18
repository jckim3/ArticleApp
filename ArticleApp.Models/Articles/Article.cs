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

        // 유효성 검사
        //[Required]
        [Required(ErrorMessage ="Please Enter the Title, It should not be empty!!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please Enter the Content, It should not be empty!!")]
        public string Content { get; set; }


        /// <summary>
        /// goji gul
        /// </summary>
        public bool IsPinned { get; set; } = false;
    }
}
