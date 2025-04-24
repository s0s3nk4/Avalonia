using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_P4_Project.Model
{
    public class Books
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string Title { get; set; }
        [Required]
        [MaxLength(128)]
        public string Description { get; set; }
        [Required]
        [MaxLength(128)]
        public string Author { get; set; }
        public virtual BookCategories Category { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
    }
}
