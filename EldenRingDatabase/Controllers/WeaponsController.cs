namespace EldenRingDatabase.Controllers
{
    using EldenRingDatabase.Data;
    using EldenRingDatabase.Data.Models;
    using EldenRingDatabase.Models;
    using EldenRingDatabase.Models.Weapons;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class WeaponsController : Controller
    {
        private readonly EldenRingDbContext data;

        public WeaponsController(EldenRingDbContext data) 
            => this.data = data;

        public IActionResult Add() => View(new AddWeaponFormModel
        {
            WeaponTypes = this.GetWeaponTypes(),
            WeaponSkills = this.GetWeaponSkills(),
            DamageTypes = this.GetDamageTypes(),
            StatusEffects = this.GetStatusEffects()
        });

        [HttpPost]
        public IActionResult Add(AddWeaponFormModel weapon)
        {
            if (!this.data.WeaponTypes.Any(w => w.Id == weapon.WeaponTypeId))
            {
                this.ModelState.AddModelError(nameof(weapon.WeaponTypeId), "Weapon type not exist.");
            }

            if (!this.data.Skills.Any(s => s.Id == weapon.SkillId))
            {
                this.ModelState.AddModelError(nameof(weapon.SkillId), "Skill not exist.");
            }

            if (!this.data.StatusEffects.Any(s => s.Id == weapon.StatusEffectId))
            {
                this.ModelState.AddModelError(nameof(weapon.StatusEffectId), "Status effect not exist.");
            }

            if (!this.ModelState.IsValid)
            {
                weapon.WeaponTypes = this.GetWeaponTypes();
                weapon.WeaponSkills = this.GetWeaponSkills();
                weapon.DamageTypes = this.GetDamageTypes();
                weapon.StatusEffects = this.GetStatusEffects();

                return View(weapon);
            }

            var weaponData = new Weapon
            {
                Name = weapon.Name,
                ImageUrl = weapon.ImageUrl,
                Discription = weapon.Description,
                WeaponTypeId = weapon.WeaponTypeId,
                DamageTypes = this.AddDamageTypes(weapon),
                SkillId = weapon.SkillId,
                Weight = double.Parse(weapon.Weight, CultureInfo.InvariantCulture),
                StatusEffectId = weapon.StatusEffectId,
                IsLegendary = weapon.IsLegendary,
                Stats = new Stats
                {
                    AttackStats = new AttackStats
                    {
                        Phy = weapon.WeaponStats.AttackStats.Phy,
                        Mag = weapon.WeaponStats.AttackStats.Mag,
                        Fire = weapon.WeaponStats.AttackStats.Fire,
                        Ligt = weapon.WeaponStats.AttackStats.Ligt,
                        Holy = weapon.WeaponStats.AttackStats.Holy,
                        Crit = weapon.WeaponStats.AttackStats.Crit
                    },
                    GuardStats = new GuardStats
                    {
                        Phy = weapon.WeaponStats.GuardStats.Phy,
                        Mag = weapon.WeaponStats.GuardStats.Mag,
                        Fire = weapon.WeaponStats.GuardStats.Fire,
                        Ligt = weapon.WeaponStats.GuardStats.Ligt,
                        Holy = weapon.WeaponStats.GuardStats.Holy,
                        Boost = weapon.WeaponStats.GuardStats.Boost
                    },
                    Scaling = new Scaling
                    {
                        Endurance = weapon.WeaponStats.Scaling.Endurance,
                        Strength = weapon.WeaponStats.Scaling.Strength,
                        Dexterity = weapon.WeaponStats.Scaling.Dexterity,
                        Intelligence = weapon.WeaponStats.Scaling.Intelligence,
                        Faith = weapon.WeaponStats.Scaling.Faith,
                        Arcane = weapon.WeaponStats.Scaling.Arcane
                    },
                    Requires = new Requires
                    {
                        Endurance = weapon.WeaponStats.Requires.Endurance,
                        Strength = weapon.WeaponStats.Requires.Strength,
                        Dexterity = weapon.WeaponStats.Requires.Dexterity,
                        Intelligence = weapon.WeaponStats.Requires.Intelligence,
                        Faith = weapon.WeaponStats.Requires.Faith,
                        Arcane = weapon.WeaponStats.Requires.Arcane
                    }
                }
            };


            this.data.Add(weaponData);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        private ICollection<DamageType> AddDamageTypes(AddWeaponFormModel weapon)
        {
            var damageTypes = new List<DamageType>();

            if (weapon.DamageTypeId != null)
            {
                foreach (var damageTypeId in weapon.DamageTypeId)
                {
                    var damageType = this.data.DamageTypes.Where(d => d.Id == damageTypeId).First();
                    damageTypes.Add(damageType);
                }
            }

            return damageTypes;
        }

        private ICollection<StatusEffectViewModel> GetStatusEffects()
            => this.data
            .StatusEffects
            .Select(s => new StatusEffectViewModel
            {
                Id = s.Id,
                Name = s.Name,
                ImageUrl = s.ImageUrl,
                Effect = s.Effect,
                Description = s.Description
            })
            .ToList();

        private ICollection<DamageTypeViewModel> GetDamageTypes()
            => this.data
            .DamageTypes
            .Select(d => new DamageTypeViewModel
            {
                Id = d.Id,
                Name = d.Name
            })
            .ToList();

        private ICollection<SkillViewModel> GetWeaponSkills()
            => this.data
            .Skills
            .Select(s => new SkillViewModel
            {
                Id = s.Id,
                Name = s.Name,
                ImageUrl = s.ImageUrl,
                Description = s.Description,
                FPCost = s.FPCost
            })
            .ToList();

        private ICollection<WeaponTypeViewModel> GetWeaponTypes()
            => this.data
            .WeaponTypes
            .Select(w => new WeaponTypeViewModel
            {
                Id = w.Id,
                Name = w.Name
            })
            .ToList();
    }
}
