using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Application.UseCases.DTO
{
    public class CommentDTO
    {  
        public string Username { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Comment { get; set; }
        public ICollection<SubCommentsDTO>? ChildComments { get; set; }
    }
    public class SubCommentsDTO
    {
        public string CommentSubContent { get; set; }
    }
    
}
