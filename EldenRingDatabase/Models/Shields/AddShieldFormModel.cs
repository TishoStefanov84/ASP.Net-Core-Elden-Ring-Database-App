namespace EldenRingDatabase.Models.Shields
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class AddShieldFormModel
    {
        [Display(Name = "Shield Name")]
        [Required]
        [StringLength(ShieldNameMaxLen, MinimumLength = ShieldNameMinLen)]
        public string Name { get; set; }

        [Display(Name = "Shield Type")]
        public int ShieldTypeId { get; init; }

        public ICollection<ShieldTypeViewModel> ShieldTypes { get; set; }

        [Display(Name = "Image")]
        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(
            int.MaxValue,
            MinimumLength = DiscriptionMinLen)]
        public string Description { get; set; }

        public StatsViewModel ShieldStats { get; set; }

        [Display(Name = "Skill")]
        public int SkillId { get; set; }

        public ICollection<SkillViewModel> ShieldSkills { get; set; }

        [Display(Name = "Damage Type")]
        public int DamageTypeId { get; set; }

        public ICollection<DamageTypeViewModel> DamageTypes { get; set; }

        [Required]
        [StringLength(WeightMaxLen, MinimumLength = WeightMinLen)]
        public string Weight { get; set; }
    }
}
