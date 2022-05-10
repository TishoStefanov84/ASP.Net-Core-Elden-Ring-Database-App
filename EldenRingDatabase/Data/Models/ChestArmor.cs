namespace EldenRingDatabase.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;
    public class ChestArmor
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(ChestArmorNameMaxLen)]
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