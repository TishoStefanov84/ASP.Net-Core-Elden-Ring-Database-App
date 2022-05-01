namespace EldenRingDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;

    public class WeaponType
    {
        public WeaponType()
            => this.Weapons = new HashSet<Weapon>();

        public int Id { get; init; }

        [Required]
        [MaxLength(WeaponTypeNameMaxLen)]
        public string Name { get; set; }

        public ICollection<Weapon> Weapons { get; init; }
    }
}