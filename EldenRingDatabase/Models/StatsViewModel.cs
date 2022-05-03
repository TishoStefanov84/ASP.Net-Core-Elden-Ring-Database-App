namespace EldenRingDatabase.Models
{
    public class StatsViewModel
    {
        public AttackStatsViewModel AttackStats { get; init; }

        public GuardStatsViewModel GuardStats { get; init; }

        public ScalingViewModel Scaling { get; init; }

        public RequiresViewModel Requires { get; init; }
    }
}