namespace EldenRingDatabase.Models.StatusEffects
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class AddStatusEffectFormModel
    {
        [Display(Name = "Status Effect Name")]
        [Required]
        [StringLength(StatusEffectNameMaxLen, MinimumLength = StatusEffectNameMinLen)]
        public string Name { get; set; }

        [Display(Name = "Image")]
        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(
            int.MaxValue,
            MinimumLength = StatusEffectEffectMinLen)]
        public string Effect { get; set; }

        [Required]
        [StringLength(
            int.MaxValue,
            MinimumLength = DiscriptionMinLen)]
        public string Description { get; set; }
    }
}
