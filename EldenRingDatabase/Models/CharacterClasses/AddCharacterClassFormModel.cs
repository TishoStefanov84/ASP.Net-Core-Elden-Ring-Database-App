namespace EldenRingDatabase.Models.CharacterClasses
{
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

        [Display(Name = "Equipment")]
        public int EquipmentId { get; init; }

        public ICollection<EquipmentViewModel> Equipment { get; set; }
    }
}
