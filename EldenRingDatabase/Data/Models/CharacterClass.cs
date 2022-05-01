namespace EldenRingDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class CharacterClass
    {
        public CharacterClass()
            => this.Equipment = new HashSet<Equipment>();

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

        public ICollection<Equipment> Equipment { get; set; }

        public int ArmorSetId { get; set; }

        public ArmorSet ArmorSet { get; init; }

        [Required]
        public string Description { get; set; }
    }
}
