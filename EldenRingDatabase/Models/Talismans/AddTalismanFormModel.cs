namespace EldenRingDatabase.Models.Talismans
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class AddTalismanFormModel
    {
        [Display(Name ="Talisman Name")]
        [Required]
        [StringLength(TalismanNameMaxLen, MinimumLength = TalismanNameMinLen)]
        public string Name { get; set; }

        [Display(Name ="Image")]
        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(
            int.MaxValue,
            MinimumLength = DiscriptionMinLen)]
        public string Description { get; set; }

        [Required]
        [StringLength(WeightMaxLen, MinimumLength = WeightMinLen)]
        public string Weight { get; set; }

        [Required]
        [StringLength(TalismanEffectMaxLen, MinimumLength = TalismanEffectMinLen)]
        public string TalismanEffect { get; set; }

        public bool IsLegendary { get; set; }
    }
}
