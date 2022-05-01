namespace EldenRingDatabase.Data
{
    using EldenRingDatabase.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class EldenRingDbContext : IdentityDbContext
    {
        public EldenRingDbContext(DbContextOptions<EldenRingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ammunition> Ammunitions { get; init; }

        public DbSet<AmmunitionType> AmmunitionTypes { get; init; }

        public DbSet<ArmorSet> ArmorSets { get; init; }

        public DbSet<ArmorStats> ArmorStats { get; init; }

        public DbSet<AttackStats> AttackStats { get; init; }

        public DbSet<CharacterClass> CharacterClasses { get; init; }

        public DbSet<ChestArmor> ChestArmors { get; init; }

        public DbSet<DamageType> DamageTypes { get; init; }

        public DbSet<DmgNegation> DmgNegations { get; init; }

        public DbSet<Equipment> Equipment { get; init; }

        public DbSet<Gauntlets> Gauntlets { get; init; }

        public DbSet<GuardStats> GuardStats { get; init; }

        public DbSet<Helm> Helms { get; init; }

        public DbSet<LegArmor> LegArmor { get; init; }

        public DbSet<MagicSpell> MagicSpells { get; init; }

        public DbSet<MagicSpellType> MagicSpellType { get; init; }

        public DbSet<Requires> Requires { get; init; }

        public DbSet<Resistance> Resistances { get; init; }

        public DbSet<Scaling> Scalings { get; init; }

        public DbSet<Shield> Shields { get; init; }

        public DbSet<ShieldType> ShieldTypes { get; init; }

        public DbSet<Skill> Skills { get; init; }

        public DbSet<Stats> Stats { get; init; }

        public DbSet<StatusEffect> StatusEffects { get; init; }

        public DbSet<Weapon> Weapons { get; init; }

        public DbSet<WeaponType> WeaponTypes { get; init; }

    }
}
