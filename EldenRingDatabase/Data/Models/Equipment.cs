namespace EldenRingDatabase.Data.Models
{
    using System.Collections.Generic;

    public class Equipment
    {
        public Equipment()
        {
            this.Weapons = new HashSet<Weapon>();
            this.Shields = new HashSet<Shield>();
            this.MagicSpells = new HashSet<MagicSpell>();
            this.Ammunitions = new HashSet<Ammunition>();
        }

        public int Id { get; init; }

        public ICollection<Weapon> Weapons { get; set; }

        public ICollection<Shield> Shields { get; set; }

        public ICollection<MagicSpell> MagicSpells { get; set; }

        public ICollection<Ammunition> Ammunitions { get; set; }
    }
}