namespace EldenRingDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Skill
    {
        public Skill()
        {
            this.Shields = new HashSet<Shield>();
            this.Weapons = new HashSet<Weapon>();
        }

        public int Id { get; init; }

        [Required]
        [MaxLength(SkillNameMaxLen)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Description { get; set; }

        public int FPCost { get; set; }

        public ICollection<Shield> Shields { get; init; }
        
        public ICollection<Weapon> Weapons { get; init; }
    }
}