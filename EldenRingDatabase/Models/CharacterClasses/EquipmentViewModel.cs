using System.Collections.Generic;

namespace EldenRingDatabase.Models.CharacterClasses
{
    public class EquipmentViewModel
    {
        public int Id { get; init; }

        public ICollection<WeaponViewModel> Weapons { get; set; }

        public ICollection<ShieldViewModel> Shields { get; set; }

        public ICollection<MagicSpellViewModel> MagicSpells { get; set; }

        public ICollection<AmmunitionViewModel> Ammunitions { get; set; }
    }
}