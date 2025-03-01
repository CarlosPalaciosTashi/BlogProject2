using System.ComponentModel.DataAnnotations;

namespace BlogProject2.Core
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "A name is obligatory")]
        [Display(Name = "Category name")]
        public string Name { get; set; }
        [Range(1, 100, ErrorMessage = "The value must be from 1 to 100")]
        public int Order { get; set; }
    }

}

