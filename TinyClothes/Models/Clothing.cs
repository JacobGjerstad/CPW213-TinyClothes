using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TinyClothes.Models
{
    /// <summary>
    /// Represents a single clothing item
    /// </summary>
    public class Clothing
    {
        /// <summary>
        /// The unique id for the clothing item
        /// </summary>
        [Key] //Set as PK
        public int ItemId { get; set; }

        /// <summary>
        /// The size of the clothing (ex: small, medium, large)
        /// </summary>
        [Required(ErrorMessage = "Size is required")]
        public string  Size { get; set; }

        /// <summary>
        /// The type of clothing (ex: hat, shirt, etc)
        /// </summary>
        [Required]
        public string Type { get; set; }

        /// <summary>
        /// The color of the clothing
        /// </summary>
        [Required]
        public string Color { get; set; }

        /// <summary>
        /// The retail price of the item
        /// </summary>
        [Range(0.0, 300.0)]
        public double Price { get; set; }

        /// <summary>
        /// The display title of the clothing item
        /// </summary>
        [Required]
        [StringLength(35)]
        // Sample Regex, great for validation
        //[RegularExpression("^([A-Za-z0-9])+$")]
        public string Title { get; set; }

        /// <summary>
        /// Description of the clothing item
        /// </summary>
        [StringLength(800)]
        public string Description { get; set; }
    }
}
