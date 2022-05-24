namespace EldenRingDatabase.Models.Weapons
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class AddWeaponFormModel
    {
        [Display(Name = "Weapon Name")]
        [Required]
        [StringLength(WeaponNameMaxLen, MinimumLength = WeaponNameMinLen)]
        public string Name { get; set; }

        [Display(Name = "Weapon Type")]
        public int WeaponTypeId { get; init; }

        public ICollection<WeaponTypeViewModel> WeaponTypes { get; set; }

        [Display(Name = "Image")]
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

        public StatsViewModel WeaponStats { get; set; }

        [Display(Name = "Skill")]
        public int SkillId { get; init; }

        public ICollection<SkillViewModel> WeaponSkills { get; set; }

        [Display(Name = "Damage Type (Press ctrl for multiple select)")]
        public ICollection<int> DamageTypeId { get; init; }

        public ICollection<DamageTypeViewModel> DamageTypes { get; set; }

        [Display(Name = "Status Effect")]
        public int StatusEffectId { get; init; }

        public ICollection<StatusEffectViewModel> StatusEffects { get; set; }

        public bool IsLegendary { get; set; }
    }
}
