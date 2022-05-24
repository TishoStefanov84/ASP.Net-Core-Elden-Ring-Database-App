namespace EldenRingDatabase.Models.Armors
{
    using EldenRingDatabase.Data.Models;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class AddChestArmorsFormModel
    {
        [Display(Name = "Chest Armor Name")]
        [Required]
        [StringLength(ChestArmorNameMaxLen, MinimumLength = ChestArmorNameMinLen)]
        public string Name { get; set; }

        [Display(Name = "Image")]
        [Required]
        [Url]
        public string ImageUrl { get; set; }


        public ArmorStatsViewModel ArmorStats { get; init; }

        [Required]
        [StringLength(WeightMaxLen, MinimumLength = WeightMinLen)]
        public string Weight { get; set; }

        [Required]
        [StringLength(
            int.MaxValue,
            MinimumLength = DiscriptionMinLen)]
        public string Description { get; set; }
    }
}
