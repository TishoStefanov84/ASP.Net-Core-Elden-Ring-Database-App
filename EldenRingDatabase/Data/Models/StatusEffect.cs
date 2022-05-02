namespace EldenRingDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class StatusEffect
    {
        public StatusEffect()
            => this.Weapons = new HashSet<Weapon>();

        public int Id { get; init; }

        [Required]
        [MaxLength(StatusEffectNameMaxLen)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Effect { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<Weapon> Weapons { get; init; } 
    }
}