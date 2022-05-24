namespace EldenRingDatabase.Models.MagicSpells
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class AddMagicSpellFormModel
    {
        [Display(Name = "Magic Spell Name")]
        [Required]
        [StringLength(MagicSpellNameMaxLen, MinimumLength = MagicSpellNameMinLen)]
        public string Name { get; set; }

        [Display(Name ="Magic Spell Type")]
        public int MagicSpellTypeId { get; init; }

        public ICollection<MagicSpellTypeViewModel> MagicSpellType { get; set; }

        [Display(Name = "Image")]
        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(
            int.MaxValue,
            MinimumLength = DiscriptionMinLen)]
        public string Description { get; set; }

        public bool IsLegendary { get; set; }

        public int FPCost { get; set; }

        public int SlotUsed { get; set; }

        [Required]
        [StringLength(
            int.MaxValue,
            MinimumLength = MagicSpellNameMinLen)]
        public string Effect { get; set; }

        public RequiresViewModel Requires { get; set; }
    }
}
