namespace EldenRingDatabase.Models.Skills
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class AddSkillFormModel
    {
        [Display(Name = "Skill Name")]
        [Required]
        [StringLength(SkillNameMaxLen, MinimumLength = SkillNameMinLen)]
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

        [Range(0, 100)]
        public int FPCost { get; set; }
    }
}
