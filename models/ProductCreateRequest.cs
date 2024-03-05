using System.ComponentModel.DataAnnotations;

namespace CIS106ExceptionHandling.models {

    public class ProductCreateRequest {

        [Required]
        [MinLength(2)]
        [MaxLength(200)]
        public string Name {get; set;}

        [Required]
        [MinLength(20)]
        [MaxLength(500)]
        public string Description {get; set;}

        [Required]
        [Range(0.00d, 9999999.99d)]
        public decimal Price {get; set;}

    }

}