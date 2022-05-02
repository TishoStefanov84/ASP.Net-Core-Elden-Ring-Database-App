namespace EldenRingDatabase.Data.Models
{
    using System.Collections.Generic;

    public class GuardStats
    {
        public GuardStats()
            => this.Stats = new HashSet<Stats>();

        public int Id { get; init; }

        public int Phy { get; set; }

        public int Mag { get; set; }

        public int Fire { get; set; }

        public int Ligt { get; set; }

        public int Holy { get; set; }

        public int Boost { get; set; }

        public ICollection<Stats> Stats { get; init; }
    }
}