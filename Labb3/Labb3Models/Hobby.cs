using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;

namespace Labb3Models
{
    public class Hobby
    {
      
        [Key]
        public int HobbyId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string Description { get; set; }

      
        public ICollection<Link> Links { get; set; }

    
        public ICollection<PersonHobby> PersonHobbies { get; set; }
    }
}
