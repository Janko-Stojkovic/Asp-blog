using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat.Application.UseCases.DTO
{
    public class CreateCommentDTO
    {
        public int UserId { get; set; }
        public string Comment { get; set; }
        public int BlogId { get; set; }
        public int? ParentId { get; set; }
    }
}
