namespace EldenRingDatabase.Infrastructure
{
    using EldenRingDatabase.Data;
    using EldenRingDatabase.Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetService<EldenRingDbContext>();

            data.Database.Migrate();

            Seed(data);

            return app;
        }

        private static void Seed(EldenRingDbContext data)
        {
            SeedAmmunitionTypes(data);
            SeedDamageTypes(data);
            SeedMagicSpellTypes(data);
            SeedShieldTypes(data);
            SeedWeaponTypes(data);
        }

        private static void SeedAmmunitionTypes(EldenRingDbContext data)
        {
            if (data.AmmunitionTypes.Any())
            {
                return;
            }

            data.AmmunitionTypes.AddRange(new[]
            {
                new AmmunitionType{Name = "Arrow"},
                new AmmunitionType{Name = "Bolt"},
                new AmmunitionType{Name = "Great Arrow"},
                new AmmunitionType{Name = "Great Bolt"},
            });

            data.SaveChanges();
        }

        private static void SeedDamageTypes(EldenRingDbContext data)
        {
            if (data.DamageTypes.Any())
            {
                return;
            }

            data.DamageTypes.AddRange(new[]
            {
                new DamageType
                {
                    Name = "Standard Damage",
                    Description = "Standard Damage is one of the Damage Types in Elden Ring. " +
                    "It is one of the eight main Damage Types and belongs to the Physical Damage " +
                    "category. Damage Types are a major part of the calculation that determines how " +
                    "much damage is dealt in Combat and are affected by many factors including your " +
                    "equipment, skills and temporary buffs.Standard Damage (also known simply as Physical Damage) " +
                    "is a broad category and acts as a catch-all for all physically dealt damage outside of " +
                    "the three subcategories: Strike Damage, Slash Damage and Pierce Damage. For any other Physical" +
                    " attacks that do not fall into these three subcategories, the damage will be calculated as " +
                    "Standard using the Physical Damage stat."
                },
                new DamageType
                {
                    Name = "Strike Damage",
                    Description = ".Strike Damage is a type of Physical " +
                    "Damage that is often associated with blunt weapons such as Hammers and Maces. Weapons that primarily " +
                    "deal the other damage types can also possess attacks that deal Strike Damage within their movesets. " +
                    "Strike damage is often (but not always) effective against heavily armored enemies as well as creatures " +
                    "made of rock or have a similar sturdy composition."
                },
                new DamageType
                {
                    Name = "Slash Damage",
                    Description = "Slash Damage is a type of Physical Damage that " +
                    "is often associated with sharp weapons such as Curved Swords, Daggers and Katanas. Weapons that primarily" +
                    " deal the other damage types can also possess attacks that deal Slash Damage within their movesets. Slash " +
                    "damage is effective against unarmored or lightly armored enemies as well as fleshy creatures."
                },
                new DamageType
                {
                    Name = "Pierce Damage",
                    Description = "Pierce Damage is a type of Physical Damage that is often associated with thrusting weapons " +
                    "such as Spears and Lances. Weapons that primarily deal the other damage types can also possess attacks that " +
                    "deal Pierce Damage within their movesets. Pierce Damage is effective against Scaly creatures such as " +
                    "Dragons as well as medium armored enemies."
                },
                new DamageType
                {
                    Name = "Magic Damage",
                    Description = "Magic Damage is a type of Elemental Damage dealt by both players and enemies alike. " +
                    "Magic Damage is elemental damage that falls outside of Fire Damage, Lightning Damage and Holy Damage types. " +
                    "Magic Damage is often effective against most enemies with high Physical resistance or are heavily armored." +
                    "Most Weapons can be upgraded via the Magic Upgrade Path in order to imbue them with Magic Damage properties. " +
                    "There are also Weapons that can be found which innately deal Magic Damage. See the Upgrades and individual " +
                    "weapon pages for details.All offensive Sorceries and certain offensive Incantations deal Magic Damage." +
                    "Weapon Arts that deal Magic Damage will benefit from Int if the weapon has Int scaling.Weapon Arts that " +
                    "deal Ice Magic Damage will benefit from Int and Dex if the weapon has scaling on either of them."
                },
                new DamageType
                {
                    Name = "Fire Damage",
                    Description = "Fire Damage is a type of Elemental Damage dealt by both players and enemies alike. Many Spells " +
                    "belonging to the Incantations category are good sources of Fire Damage. Fire Damage is particularly effective " +
                    "against unarmored enemies, fleshy creatures as well as the undead. Most enemies that utilize Fire Damage will often" +
                    " (but not always) have high resistance or immunity to Fire Damage.Ashes of War that deal fire damage can be infused " +
                    "either as Fire, or as Flame Art. If infused as Fire, the primary scaling will be with Strength with minor Dex scaling." +
                    " If infused with Flame Art, the Str and Dex scaling get severely reduced, and the fire damage scales strongly with Faith."
                },
                new DamageType
                {
                    Name = "Lightning Damage",
                    Description = "Lightning Damage is a type of Elemental Damage dealt by both players and enemies alike. Lightning Damage is " +
                    "often effective against heavily armored enemies, dragons and other draconic or serpentine creatures. Most enemies that" +
                    " utilize Lightning Damage will often (but not always) have high resistance or immunity to Lightning Damage." +
                    "Most Weapons can be upgraded via the Lightning Upgrade Path in order to imbue them with Lightning Damage properties. " +
                    "There are also Weapons that can be found which innately deal Lightning Damage. See the Upgrades and individual " +
                    "weapon pages for details.Weapon Arts that deal Lightning Damage will benefit from Dex if the weapon has Dex scaling."
                },
                new DamageType
                {
                    Name = "Holy Damage",
                    Description = "Holy Damage is a type of Elemental Damage dealt by both players and enemies alike. " +
                    "Holy Damage is often effective against Undead creatures. Most enemies that utilize Holy Damage " +
                    "will often (but not always) have high resistance or immunity to Holy Damage.Most Shields can be " +
                    "upgraded via the Sacred Upgrade Path in order to imbue them with Holy Damage properties. There " +
                    "are also Weapons that can be found which innately deal Holy Damage. See the Upgrades and individual " +
                    "weapon pages for details.Certain offensive Incantations deal Holy Damage.Weapon Arts that deal " +
                    "Holy Damage will benefit from Faith if the weapon has Faith scaling."
                },
                new DamageType
                {
                    Name = "Critical Damage",
                    Description = "Critical Damage is a special type of damage stat that can be found on all Weapons. " +
                    "Critical Damage is a modifier used when calculating the damage dealt by Critical Attacks.If performed correctly, " +
                    "the player and the target are locked in a short animation where the player performs a highly damaging attack, " +
                    "often finishing off weaker enemies instantly. The animation varies by Weapon type and neither the player nor the " +
                    "target can be damaged by outside sources until the animation has finished."
                },
            });

            data.SaveChanges();
        }

        private static void SeedMagicSpellTypes(EldenRingDbContext data)
        {
            if (data.MagicSpellType.Any())
            {
                return;
            }

            data.MagicSpellType.AddRange(new[]
            {
                new MagicSpellType {MagicSpellTypeName = "Sorcery"},
                new MagicSpellType {MagicSpellTypeName = "Incatation"}
            });

            data.SaveChanges();
        }

        private static void SeedShieldTypes(EldenRingDbContext data)
        {
            if (data.ShieldTypes.Any())
            {
                return;
            }

            data.ShieldTypes.AddRange(new[]
            {
                new ShieldType{Name = "Small Shields"},
                new ShieldType{Name = "Medium Shields"},
                new ShieldType{Name = "Great Shields"},
            });

            data.SaveChanges();
        }

        private static void SeedWeaponTypes(EldenRingDbContext data)
        {
            if (data.WeaponTypes.Any())
            {
                return;
            }

            data.WeaponTypes.AddRange(new[]
            {
                new WeaponType{Name = "Daggers"},
                new WeaponType{Name = "Straight Swords"},
                new WeaponType{Name = "Greatswords"},
                new WeaponType{Name = "Colossal Swords"},
                new WeaponType{Name = "Thrusting Swords"},
                new WeaponType{Name = "Heavy Thrusting Swords"},
                new WeaponType{Name = "Curved Swords"},
                new WeaponType{Name = "Curved Greatswords"},
                new WeaponType{Name = "Katanas"},
                new WeaponType{Name = "Twinblades"},
                new WeaponType{Name = "Axes"},
                new WeaponType{Name = "Greataxes"},
                new WeaponType{Name = "Hammers"},
                new WeaponType{Name = "Flails"},
                new WeaponType{Name = "Great Hammers"},
                new WeaponType{Name = "Colossal Weapons"},
                new WeaponType{Name = "Spears"},
                new WeaponType{Name = "Great Spears"},
                new WeaponType{Name = "Halberds"},
                new WeaponType{Name = "Reapers"},
                new WeaponType{Name = "Whips"},
                new WeaponType{Name = "Fists"},
                new WeaponType{Name = "Claws"},
                new WeaponType{Name = "Light Bows"},
                new WeaponType{Name = "Bows"},
                new WeaponType{Name = "Greatbows"},
                new WeaponType{Name = "Crossbows"},
                new WeaponType{Name = "Ballistae"},
                new WeaponType{Name = "Glinstone Staffs"},
                new WeaponType{Name = "Sacred Seals"},
                new WeaponType{Name = "Torches"},
            });

            data.SaveChanges();
        }
    }
}
