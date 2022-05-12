namespace EldenRingDatabase.Models.Armors
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class DmgNegationViewModel
    {
        [Range(0, 1000)]
        public int Phy { get; set; }

        [Range(0, 1000)]
        public int VSStrike { get; set; }

        [Range(0, 1000)]
        public int VSSlash { get; set; }

        [Range(0, 1000)]
        public int VSPierce { get; set; }

        [Range(0, 1000)]
        public int Magic { get; set; }

        [Range(0, 1000)]
        public int Fire { get; set; }

        [Range(0, 1000)]
        public int Ligt { get; set; }

        [Range(0, 1000)]
        public int Holy { get; set; }
    }
}
