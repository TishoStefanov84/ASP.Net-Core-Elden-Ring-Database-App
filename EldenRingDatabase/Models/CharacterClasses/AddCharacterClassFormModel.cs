namespace EldenRingDatabase.Models.CharacterClasses
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class AddCharacterClassFormModel
    {
        [Display(Name = "Class Name")]
        [Required]
        [StringLength(CharacterClassNameMaxLen, MinimumLength = CharacterClassNameMinLen)]
        public string Name { get; set; }

        [Display(Name = "Image")]
        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [Range(0, 50)]
        public int RuneLevel { get; set; }

        [Range(0, 50)]
        public int Vigor { get; set; }

        [Range(0, 50)]
        public int Mind { get; set; }

        [Range(0, 50)]
        public int Endurance { get; set; }

        [Range(0, 50)]
        public int Strength { get; set; }

        [Range(0, 50)]
        public int Dexterity { get; set; }

        [Range(0, 50)]
        public int Intelligence { get; set; }

        [Range(0, 50)]
        public int Faith { get; set; }

        [Range(0, 50)]
        public int Arcane { get; set; }

        [Required]
        [StringLength(
            int.MaxValue,
            MinimumLength = DiscriptionMinLen)]
        public string Description { get; set; }

        [Display(Name = "Armor Set")]
        public int ArmorSetId { get; init; }

        public ICollection<ArmorSetViewModel> ArmorSets { get; set; }

        [Display(Name = "Weapons (Press ctrl for multiple select)")]
        public List<int> WeaponId { get; init; }

        public ICollection<WeaponViewModel> Weapons { get; set; }

        [Display(Name = "Shields (Press ctrl for multiple select)")]
        public List<int> ShieldId { get; init; }

        public ICollection<ShieldViewModel> Shields { get; set; }

        [Display(Name = "Magic Spells (Press ctrl for multiple select)")]
        public List<int> MagicSpellId { get; init; }

        public ICollection<MagicSpellViewModel> MagicSpells { get; set; }

        [Display(Name = "Ammunitions (Press ctrl for multiple select)")]
        public List<int> AmmunitionId { get; init; }

        public ICollection<AmmunitionViewModel> Ammunitions { get; set; }

        public EquipmentViewModel Equipment { get; set; }

    }
}
