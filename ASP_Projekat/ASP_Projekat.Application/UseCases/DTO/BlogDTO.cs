namespace ASP_Projekat.Application.UseCases.DTO
{
    public class BlogDTO
    {
        public int Id { get; set; }
        public string BlogContent { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<BlogCommentsDTO>? BlogComments { get; set; }
        public IEnumerable<BlogReactionsDTO>? BlogReactions { get; set; }
        public IEnumerable<BlogImageDTO>? BlogImages { get; set; }
        public IEnumerable<BlogTagDTO>? BlogTags { get; set; }
    }

    public class BlogCommentsDTO
    {
        public string Username { get; set; }
        public string CommentContent { get; set; }
        public int? ParentId { get; set; }
    }

    public class BlogReactionsDTO
    {
        public string UserReacted { get; set; }
        public string ReactionName { get; set; }
    }

    
}
