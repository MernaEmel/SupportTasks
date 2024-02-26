using SupportTask2.utilities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupportTask2.Models
{
    public class Blog
    {
        [Key]

        public int Id { get; set; }
        [Required(ErrorMessage = "You must enter the title of the Blog")]
        [MaxLength(6)]
        [MinLength(1)]

        public string Title { get; set; }
        [Required(ErrorMessage = "You must enter the Discription of the Blog")]
        public string Description { get; set; }
        [Required(ErrorMessage = "You must enter the profit of the Blog")]
        [Range(0,10000)]
        [CustomValidation1(500)]
        [CustomValidation2]
        public int profit { get; set; }
        
        public bool IsFree { get; set; }
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public BlogType? Type { get; set; } 
    }
}
