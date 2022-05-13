namespace EldenRingDatabase.Models.Armors
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class DmgNegationViewModel
    {
        [Required]
        [StringLength(DmgNegationPropMaxLen, MinimumLength = DmgNegationPropMinLen)]
        public string Phy { get; set; }

        [Required]
        [StringLength(DmgNegationPropMaxLen, MinimumLength = DmgNegationPropMinLen)]
        public string VSStrike { get; set; }

        [Required]
        [StringLength(DmgNegationPropMaxLen, MinimumLength = DmgNegationPropMinLen)]
        public string VSSlash { get; set; }

        [Required]
        [StringLength(DmgNegationPropMaxLen, MinimumLength = DmgNegationPropMinLen)]
        public string VSPierce { get; set; }

        [Required]
        [StringLength(DmgNegationPropMaxLen, MinimumLength = DmgNegationPropMinLen)]
        public string Magic { get; set; }

        [Required]
        [StringLength(DmgNegationPropMaxLen, MinimumLength = DmgNegationPropMinLen)]
        public string Fire { get; set; }

        [Required]
        [StringLength(DmgNegationPropMaxLen, MinimumLength = DmgNegationPropMinLen)]
        public string Ligt { get; set; }

        [Required]
        [StringLength(DmgNegationPropMaxLen, MinimumLength = DmgNegationPropMinLen)]
        public string Holy { get; set; }
    }
}
