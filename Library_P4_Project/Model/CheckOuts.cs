using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_P4_Project.Model
{
    public class CheckOuts
    {
        [Key]
        public int Id { get; set; }
        public virtual Books Book { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        [Required]
        [MaxLength(128)]
        public string Reader { get; set; }
        [Required]
        [MaxLength(128)]
        public string Phone { get; set; }
        [Required]
        public DateTime CheckOutDate { get; set; }
        public DateTime CheckInDate { get; set; }
    }
}
