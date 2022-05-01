namespace EldenRingDatabase.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Gauntlets
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(GauntletsNameMaxLen)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int ArmorStatsId { get; set; }

        public ArmorStats ArmorStats { get; init; }

        public double Weight { get; set; }

        [Required]
        public string Description { get; set; }
    }
}