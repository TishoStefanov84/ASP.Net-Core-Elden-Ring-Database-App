namespace EldenRingDatabase.Models
{
    using System.ComponentModel.DataAnnotations;

    public class GuardStatsViewModel
    {
        [Range(0, 1000)]
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
        public int Boost { get; set; }
    }
}