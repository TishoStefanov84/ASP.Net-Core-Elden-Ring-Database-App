namespace EldenRingDatabase.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class CharacterClass
    {

        public int Id { get; init; }

        [Required]
        [MaxLength(CharacterClassNameMaxLen)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int RuneLevel { get; set; }

        public int Vigor { get; set; }

        public int Mind { get; set; }

        public int Endurance { get; set; }

        public int Strength { get; set; }

        public int Dexterity { get; set; }

        public int Intelligence { get; set; }

        public int Faith { get; set; }

        public int Arcane { get; set; }

        public int EquipmentId { get; set; }

        public Equipment Equipment { get; init; }

        public int ArmorSetId { get; set; }

        public ArmorSet ArmorSet { get; init; }

        [Required]
        public string Description { get; set; }
    }
}
