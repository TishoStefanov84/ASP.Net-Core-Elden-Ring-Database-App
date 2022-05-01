namespace EldenRingDatabase.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class MagicSpell
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(MagicSpellNameMaxLen)]
        public string Name { get; set; }

        public int MagicSpellTypeId { get; set; }

        public MagicSpellType MagicSpellType { get; init; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsLegendary { get; set; }

        public int FPCost { get; set; }

        public int SlotUsed { get; set; }

        [Required]
        public string Effect { get; set; }

        public int RequiresId { get; set; }

        public Requires Requires { get; init; }
    }
}