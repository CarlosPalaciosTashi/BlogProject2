using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogProject2.Core{


    public class Article{

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Article name is obligatory")]
        [Display(Name = "Article Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is obligatory")]
        public string Description { get; set; }

        [Display(Name = "Creation Date")]
        public string CreationDate { get; set; }

        [Display(Name = "Image")]
        [DataType (DataType.ImageUrl)]
        public string UrlImage { get; set; }

        [Required(ErrorMessage = "Category is obligatory")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}