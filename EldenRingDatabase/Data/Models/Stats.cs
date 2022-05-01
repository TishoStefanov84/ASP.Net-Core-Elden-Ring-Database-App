namespace EldenRingDatabase.Data.Models
{
    public class Stats
    {
        public int Id { get; init; }

        public int AttackStatsId { get; set; }

        public AttackStats AttackStats { get; init; }

        public int GuardStatsId { get; set; }

        public GuardStats GuardStats { get; init; }

        public int ScalingId { get; set; }

        public Scaling Scaling { get; init; }

        public int RequiresId { get; set; }

        public Requires Requires { get; init; }
    }
}