using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.dto.comment
{
    public class UpdateCommentDto
    {
        [Required]
        [MinLength(5,ErrorMessage="Title Must be 5 char")]
        [MaxLength(20,ErrorMessage ="Title cannot be over 20 char")]
        public string Title {get;set;} = string.Empty;

        [Required]
        [MinLength(5,ErrorMessage="Content Must be 5 char")]
        [MaxLength(50,ErrorMessage ="Content cannot be over 50 char")]
        public string Content{get;set;} = string.Empty; 
    }
}