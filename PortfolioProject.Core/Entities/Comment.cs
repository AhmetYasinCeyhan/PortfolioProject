using System;

namespace PortfolioProject.Core.Entities
{
    public class Comment : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public bool IsApproved { get; set; } = false;
        public DateTime CommentDate { get; set; } = DateTime.Now;
        public int BlogId { get; set; }
        public int? ParentCommentId { get; set; }
        
        // Navigation properties
        public Blog Blog { get; set; }
        public Comment ParentComment { get; set; }
    }
}
