namespace EldenRingDatabase.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;
    public class LegArmor
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(LegArmorNameMaxLen)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int ArmorStatsId { get; set; }

        public ArmorStats ArmorStats { get; init; }

        [Required]
        [MaxLength(WeightMaxLen)]
        public string Weight { get; set; }

        [Required]
        public string Description { get; set; }
    }
}