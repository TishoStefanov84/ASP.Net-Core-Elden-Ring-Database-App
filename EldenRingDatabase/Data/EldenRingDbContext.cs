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

        public DbSet<Talisman> Talismans { get; init; }

        public DbSet<TalismanEffect> TalismanEffects { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           builder
               .Entity<Ammunition>()
               .HasOne(a => a.AmmunitionType)
               .WithMany(a => a.Ammunitions)
               .HasForeignKey(a => a.AmmunitionTypeId)
               .OnDelete(DeleteBehavior.Restrict);
           
           builder
               .Entity<Ammunition>()
               .HasOne(a => a.DamageType)
               .WithMany(d => d.Ammunitions)
               .HasForeignKey(a => a.DamageTypeId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<MagicSpell>()
                .HasOne(m => m.MagicSpellType)
                .WithMany(m => m.MagicSpells)
                .HasForeignKey(m => m.MagicSpellTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Shield>()
                .HasOne(s => s.ShieldType)
                .WithMany(s => s.Shields)
                .HasForeignKey(s => s.ShieldTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .Entity<Shield>()
               .HasOne(s => s.Skill)
               .WithMany(s => s.Shields)
               .HasForeignKey(s => s.SkillId)
               .OnDelete(DeleteBehavior.Restrict);
            builder
               .Entity<Stats>()
               .HasOne(s => s.AttackStats)
               .WithMany(a => a.Stats)
               .HasForeignKey(s => s.AttackStatsId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
               .Entity<Stats>()
               .HasOne(s => s.GuardStats)
               .WithMany(g => g.Stats)
               .HasForeignKey(s => s.GuardStatsId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
               .Entity<Stats>()
               .HasOne(s => s.Scaling)
               .WithMany(s => s.Stats)
               .HasForeignKey(s => s.ScalingId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
             .Entity<Stats>()
             .HasOne(s => s.Requires)
             .WithMany(r => r.Stats)
             .HasForeignKey(s => s.RequiresId)
             .OnDelete(DeleteBehavior.Restrict);

            builder
             .Entity<Weapon>()
             .HasOne(w => w.WeaponType)
             .WithMany(w => w.Weapons)
             .HasForeignKey(w => w.WeaponTypeId)
             .OnDelete(DeleteBehavior.Restrict);

            builder
             .Entity<Weapon>()
             .HasOne(w => w.Skill)
             .WithMany(s => s.Weapons)
             .HasForeignKey(w => w.SkillId)
             .OnDelete(DeleteBehavior.Restrict);

            builder
             .Entity<Weapon>()
             .HasOne(w => w.StatusEffect)
             .WithMany(w => w.Weapons)
             .HasForeignKey(w => w.StatusEffectId)
             .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<TalismanEffect>()
                .HasOne(t => t.Talisman)
                .WithMany(t => t.TalismanEffects)
                .HasForeignKey(t => t.TalismanId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

    }
}
