namespace EldenRingDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class MagicSpellType
    {
        public MagicSpellType()
            => this.MagicSpells = new HashSet<MagicSpell>();
        public int Id { get; init; }

        [Required]
        [MaxLength(MagicSpellTypeNameMaxLen)]
        public string MagicSpellTypeName { get; set; }

        public ICollection<MagicSpell> MagicSpells { get; init; }
    }
}