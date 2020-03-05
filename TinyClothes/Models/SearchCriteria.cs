using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TinyClothes.Models
{
    public class SearchCriteria
    {
        public SearchCriteria()
        {
            Results = new List<Clothing>();
        }

        public string Size { get; set; }

        /// <summary>
        /// The type of clothing (shirt/pants/hat/etc)
        /// </summary>
        public string Type { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [Display(Name = "Min Price")]
        [Range(0.0, double.MaxValue, ErrorMessage = "Min Value must be positive")]
        public double? MinPrice { get; set; }

        [Display(Name = "Max Price")]
        [Range(0.0, double.MaxValue, ErrorMessage = "Max Value must be positive")]
        public double? MaxPrice { get; set; }

        public List<Clothing> Results { get; set; }

        /// <summary>
        /// Returns true if at least one criteria is provided
        /// </summary>
        public bool IsBeingSearched()
        {
            return MaxPrice.HasValue || MinPrice.HasValue || Title != null || Type != null || Size != null;
        }
    }
}
