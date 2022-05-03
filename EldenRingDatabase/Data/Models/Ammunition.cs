namespace EldenRingDatabase.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Ammunition
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(AmmunitionNameMaxLen)]
        public string Name { get; set; }

        public int AmmunitionTypeId { get; set; }

        public AmmunitionType AmmunitionType { get; init; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Description { get; set; }

        public int AttackStatsId { get; set; }

        public AttackStats AttackStats { get; init; }

        public int DamageTypeId { get; set; }

        public DamageType DamageType { get; set; }


    }
}