using System.Collections.Generic;

namespace EldenRingDatabase.Models.CharacterClasses
{
    public class EquipmentViewModel
    {
        public EquipmentViewModel()
        {
            this.Weapons = new List<WeaponViewModel>();
        }
        public int Id { get; init; }

        public ICollection<WeaponViewModel> Weapons { get; set; }

        public ICollection<ShieldViewModel> Shields { get; set; }

        public ICollection<MagicSpellViewModel> MagicSpells { get; set; }

        public ICollection<AmmunitionViewModel> Ammunitions { get; set; }
    }
}