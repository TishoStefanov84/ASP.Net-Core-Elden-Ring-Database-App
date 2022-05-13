namespace EldenRingDatabase.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;
    public class ArmorSet
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(ArmorSetNameMaxLen)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public double Weight { get; set; }

        public int ArmorStatsId { get; set; }

        public ArmorStats ArmorStats { get; init; }

        public int HelmId { get; set; }

        public Helm Helm { get; init; }

        public int ChestArmorId { get; set; }

        public ChestArmor ChestArmor { get; init; }

        public int GauntletsId { get; set; }

        public Gauntlets Gauntlets { get; init; }

        public int LegArmorId { get; set; }

        public LegArmor LegArmor { get; init; }

        [Required]
        public string Description { get; set; }
    }
}