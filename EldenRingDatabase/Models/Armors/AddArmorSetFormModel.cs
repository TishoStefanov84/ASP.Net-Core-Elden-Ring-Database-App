namespace EldenRingDatabase.Models.Armors
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class AddArmorSetFormModel
    {
        [Display(Name = "Armor Set Name")]
        [Required]
        [StringLength(ArmorSetNameMaxLen, MinimumLength = ArmorSetNameMinLen)]
        public string Name { get; set; }

        [Display(Name = "Image")]
        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(
            int.MaxValue,
            MinimumLength = DiscriptionMinLen)]
        public string Description { get; set; }
    }
}
