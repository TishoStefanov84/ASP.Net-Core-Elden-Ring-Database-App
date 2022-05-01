namespace EldenRingDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Weapon
    {
        public Weapon()
        {
            this.DamageTypes = new HashSet<DamageType>();
        }
        public int Id { get; init; }

        [Required]
        [MaxLength(WeaponNameMaxLen)]
        public string Name { get; set; }

        [Required]
        [MaxLength(WeaponTypeMaxLen)]
        public string Type { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Discription { get; set; }

        public double Weight { get; set; }

        public int StatsId { get; set; }

        public Stats Stats { get; set; }

        public int SkillId { get; set; }

        public Skill Skill { get; init; }

        public ICollection<DamageType> DamageTypes { get; init; }

        public int StatusEffectId { get; set; }

        public StatusEffect StatusEffect { get; set; }

        public bool IsLegendary { get; set; }
    }
}