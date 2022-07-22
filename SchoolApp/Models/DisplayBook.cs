using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApp.Models
{
    public class DisplayBook
    {
        [Key]
        public int Id { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public int BookCost { get; set; }

        //Navigation Properties
        public AddBook BookId { get; set; }
        
    }
}
