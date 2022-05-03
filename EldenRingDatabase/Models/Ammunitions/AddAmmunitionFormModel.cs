namespace EldenRingDatabase.Models.Ammunitions
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class AddAmmunitionFormModel
    {
        [Display(Name = "Ammunition Name")]
        [Required]
        [StringLength(AmmunitionNameMaxLen, MinimumLength = AmmunitionNameMinLen)]
        public string Name { get; set; }

        [Display(Name = "Ammunition Type")]
        public int AmmunitionTypeId { get; init; }

        public ICollection<AmmunitionTypeViewModel> AmmunitionTypes { get; set; }

        [Display(Name = "Image")]
        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(
            int.MaxValue, 
            MinimumLength = DiscriptionMinLen)]
        public string Description { get; set; }

        public AttackStatsViewModel AttackStats { get; set; }

        [Display(Name = "Ammunition Type")]
        public int DamageTypeId { get; init; }

        public ICollection<DamageTypeViewModel> DamageTypes { get; set; }
    }
}
