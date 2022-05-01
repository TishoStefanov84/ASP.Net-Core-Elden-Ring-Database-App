namespace EldenRingDatabase.Data.Models
{
    public class AttackStats
    {
        public int Id { get; init; }

        public int Phy { get; set; }

        public int Mag { get; set; }

        public int Fire { get; set; }

        public int Ligt { get; set; }

        public int Holy { get; set; }

        public int Crit { get; set; }

        public int? Sor { get; set; }

        public int? Inc { get; set; }
    }
}