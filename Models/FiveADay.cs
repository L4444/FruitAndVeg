using System.ComponentModel.DataAnnotations;

namespace FruitAndVegApp
{

    public class FiveADay
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(20, ErrorMessage = "Name cannot be longer than 20 letters")]
        public string Name { get; set; } = "";

        [Range(1, 5, ErrorMessage = "Star rating needs to be set")]
        public int Stars { get; set; }
    }
}