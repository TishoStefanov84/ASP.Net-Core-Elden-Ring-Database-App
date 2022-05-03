namespace EldenRingDatabase.Models.Ammunitions
{
    using System.ComponentModel.DataAnnotations;

    public class AttackStatsViewModel
    {
        [Range(0 , 1000)]
        public int Phy { get; set; }

        [Range(0, 1000)]
        public int Mag { get; set; }

        [Range(0, 1000)]
        public int Fire { get; set; }

        [Range(0, 1000)]
        public int Ligt { get; set; }

        [Range(0, 1000)]
        public int Holy { get; set; }

        [Range(0, 1000)]
        public int Crit { get; set; }

        [Range(0, 1000)]
        public int? Sor { get; set; }

        [Range(0, 1000)]
        public int? Inc { get; set; }
    }
}
