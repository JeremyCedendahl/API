using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;

namespace Labb3Models
{
    public class Link
    {
        [Key]
        public int LinkId { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string URL { get; set; }

        //En länk ska vara kopplad till en person...
        public int PersonId { get; set; }
        public Person Person { get; set; }

        //..och till ett visst intresse
        public int HobbyId { get; set; }
        public Hobby Hobby { get; set; }


    }
}