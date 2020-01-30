﻿using System;
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
        public string  Size { get; set; }

        /// <summary>
        /// The type of clothing (ex: hat, shirt, etc)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The color of the clothing
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// The retail price of the item
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// The display title of the clothing item
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Description of the clothing item
        /// </summary>
        public string Description { get; set; }
    }
}
