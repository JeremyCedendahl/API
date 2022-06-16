using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Design;

namespace Labb3Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(25)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(25)]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

       
        public ICollection<Link> Links { get; set; }


        public ICollection<PersonHobby> PersonHobbies { get; set; }

    }
}