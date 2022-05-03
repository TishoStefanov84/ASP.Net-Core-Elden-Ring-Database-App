namespace EldenRingDatabase.Controllers
{
    using EldenRingDatabase.Data;
    using EldenRingDatabase.Data.Models;
    using EldenRingDatabase.Models;
    using EldenRingDatabase.Models.Shields;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    public class ShieldsController : Controller
    {
        private readonly EldenRingDbContext data;

        public ShieldsController(EldenRingDbContext data)
           => this.data = data;

        public IActionResult Add() => View(new AddShieldFormModel
        {
            ShieldTypes = this.GetShieldTypes(),
            ShieldSkills = this.GetShieldSkills(),
            DamageTypes = this.GetDamageTypes()
        });

        [HttpPost]
        public IActionResult Add(AddShieldFormModel shield, StatsViewModel stats)
        {
            if (!this.data.ShieldTypes.Any(s => s.Id == shield.ShieldTypeId))
            {
                this.ModelState.AddModelError(nameof(shield.ShieldTypeId), "Shield type not exist.");
            }

            if (!this.data.Skills.Any(s => s.Id == shield.SkillId))
            {
                this.ModelState.AddModelError(nameof(shield.SkillId), "Skill not exist");
            }

            if (!this.data.DamageTypes.Any(d => d.Id == shield.DamageTypeId))
            {
                this.ModelState.AddModelError(nameof(Shield.DamageTypeId), "Damage type not exist");
            }

            if (!this.ModelState.IsValid)
            {
                shield.ShieldTypes = GetShieldTypes();
                shield.ShieldSkills = GetShieldSkills();
                shield.DamageTypes = GetDamageTypes();

                return View(shield);
            }

            var shieldData = new Shield
            {
                Name = shield.Name,
                ImageUrl = shield.ImageUrl,
                Description = shield.Description,
                ShieldTypeId = shield.ShieldTypeId,
                SkillId = shield.SkillId,
                Weight = shield.Weight,
                DamageTypeId = shield.DamageTypeId,
                Stats = new Stats
                {
                    AttackStats = new AttackStats
                    {
                        Phy = stats.AttackStats.Phy,
                        Mag = stats.AttackStats.Mag,
                        Fire = stats.AttackStats.Fire,
                        Ligt = stats.AttackStats.Ligt,
                        Holy = stats.AttackStats.Holy,
                        Crit = stats.AttackStats.Crit
                    },
                    GuardStats = new GuardStats
                    {
                        Phy = stats.GuardStats.Phy,
                        Mag = stats.GuardStats.Mag,
                        Fire = stats.GuardStats.Fire,
                        Ligt = stats.GuardStats.Ligt,
                        Holy = stats.GuardStats.Holy,
                        Boost = stats.GuardStats.Boost
                    },
                    Scaling = new Scaling
                    {
                        Endurance = stats.Scaling.Endurance,
                        Strength = stats.Scaling.Strength,
                        Dexterity = stats.Scaling.Dexterity,
                        Intelligence = stats.Scaling.Intelligence,
                        Faith = stats.Scaling.Faith,
                        Arcane = stats.Scaling.Arcane
                    },
                    Requires = new Requires
                    {
                        Endurance = stats.Requires.Endurance,
                        Strength = stats.Requires.Strength,
                        Dexterity = stats.Requires.Dexterity,
                        Intelligence = stats.Requires.Intelligence,
                        Faith = stats.Requires.Faith,
                        Arcane = stats.Requires.Arcane
                    }
                }
            };

            this.data.Add(shieldData);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        private ICollection<ShieldTypeViewModel> GetShieldTypes()
            => this.data
            .ShieldTypes
            .Select(s => new ShieldTypeViewModel
            {
                Id = s.Id,
                Name = s.Name
            })
            .ToList();

        private ICollection<SkillViewModel> GetShieldSkills()
            => this.data
            .Skills
            .Select(s => new SkillViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                FPCost = s.FPCost,
                ImageUrl = s.ImageUrl
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
    }
}
