using System.ComponentModel.DataAnnotations;

namespace CarsMVC.Models
{
    public class Car
    {
        
        public int Id { get; set; }
        [Required]
        public Manufacturer Manufacturer { get; set; }
        [Required]
        public Name Name { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Engine { get; set; }
        [Required]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Poster")]
        public string ImageUrl { get; set; }
    }
}
