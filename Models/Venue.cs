using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class Venue
    {
        public int VenueId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Location { get; set; } = string.Empty;

        [Range(1, 100000)]
        public int Capacity { get; set; }

        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }

        public ICollection<Event>? Events { get; set; }
    }
}