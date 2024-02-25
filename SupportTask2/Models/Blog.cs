using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupportTask2.Models
{
    public class Blog
    {
        [Key]

        public int Id { get; set; }
        [Required(ErrorMessage = "You must enter the title of the Blog")]


        public string Title { get; set; }
        [Required(ErrorMessage = "You must enter the Discription of the Blog")]
        public string Description { get; set; }
        [Required(ErrorMessage = "You must enter the profit of the Blog")]
        public int profit { get; set; }
        
        public bool IsFree { get; set; }
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public BlogType Type { get; set; } 
    }
}
