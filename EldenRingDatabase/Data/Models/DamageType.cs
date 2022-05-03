namespace EldenRingDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class DamageType
    {
        public DamageType()
        {
            this.Ammunitions = new HashSet<Ammunition>();
            this.Weapons = new HashSet<Weapon>();
            this.Shields = new HashSet<Shield>();
        }

        public int Id { get; init; }

        [Required]
        [MaxLength(DamageTypeNameMaxLen)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<Ammunition> Ammunitions { get; init; }

        public ICollection<Weapon> Weapons { get; init; }

        public ICollection<Shield> Shields { get; init; }
    }
}