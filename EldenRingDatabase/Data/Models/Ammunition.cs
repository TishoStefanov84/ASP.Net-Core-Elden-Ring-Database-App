namespace EldenRingDatabase.Data.Models
{
    public class Ammunition
    {
        public int Id { get; init; }

        public string Name { get; set; }

        public int AmmunitionTypeId { get; set; }

        public AmmunitionType AmmunitionType { get; init; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public int AttackStatsId { get; set; }

        public AttackStats AttackStats { get; init; }

        public int DamageTypeId { get; set; }

        public DamageType DamageType { get; set; }


    }
}