namespace EldenRingDatabase.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Helm
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(HelmNameMaxLen)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int ArmorStatsId { get; set; }
        
        public ArmorStats ArmorStats { get; init; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public string Description { get; set; }
    }
}