namespace EldenRingDatabase.Data.Models
{
    using System.Collections.Generic;

    public class AttackStats
    {
        public AttackStats()
            => this.Stats = new HashSet<Stats>();

        public int Id { get; init; }

        public int Phy { get; set; }

        public int Mag { get; set; }

        public int Fire { get; set; }

        public int Ligt { get; set; }

        public int Holy { get; set; }

        public int Crit { get; set; }

        public int? Sor { get; set; }

        public int? Inc { get; set; }

        public ICollection<Stats> Stats { get; init; }
    }
}