namespace OutletShop.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;

    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Must be between 1-100")]

        public int DisplayOrder { get; set; }
    }
}
