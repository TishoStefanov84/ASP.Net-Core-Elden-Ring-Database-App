namespace EldenRingDatabase.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Shield
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(ShieldNameMaxLen)]
        public string Name { get; set; }

        public int ShieldTypeId { get; set; }

        public ShieldType ShieldType { get; init; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Description { get; set; }

        public int StatsId { get; set; }

        public Stats Stats { get; set; }

        public int SkillId { get; set; }

        public Skill Skill { get; set; }

        [Required]
        [MaxLength(WeightMaxLen)]
        public string Weight { get; set; }

        public int DamageTypeId { get; set; }

        public DamageType DamageType { get; set; }
    }
}