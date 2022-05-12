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
        public IActionResult Add(AddShieldFormModel shield)
        {
            if (!this.data.ShieldTypes.Any(s => s.Id == shield.ShieldTypeId))
            {
                this.ModelState.AddModelError(nameof(shield.ShieldTypeId), "Shield type not exist.");
            }

            if (!this.data.Skills.Any(s => s.Id == shield.SkillId))
            {
                this.ModelState.AddModelError(nameof(shield.SkillId), "Skill not exist.");
            }

            if (!this.data.DamageTypes.Any(d => d.Id == shield.DamageTypeId))
            {
                this.ModelState.AddModelError(nameof(shield.DamageTypeId), "Damage type not exist.");
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
                        Phy = shield.ShieldStats.AttackStats.Phy,
                        Mag = shield.ShieldStats.AttackStats.Mag,
                        Fire = shield.ShieldStats.AttackStats.Fire,
                        Ligt = shield.ShieldStats.AttackStats.Ligt,
                        Holy = shield.ShieldStats.AttackStats.Holy,
                        Crit = shield.ShieldStats.AttackStats.Crit
                    },
                    GuardStats = new GuardStats
                    {
                        Phy = shield.ShieldStats.GuardStats.Phy,
                        Mag = shield.ShieldStats.GuardStats.Mag,
                        Fire = shield.ShieldStats.GuardStats.Fire,
                        Ligt = shield.ShieldStats.GuardStats.Ligt,
                        Holy = shield.ShieldStats.GuardStats.Holy,
                        Boost = shield.ShieldStats.GuardStats.Boost
                    },
                    Scaling = new Scaling
                    {
                        Endurance = shield.ShieldStats.Scaling.Endurance,
                        Strength = shield.ShieldStats.Scaling.Strength,
                        Dexterity = shield.ShieldStats.Scaling.Dexterity,
                        Intelligence = shield.ShieldStats.Scaling.Intelligence,
                        Faith = shield.ShieldStats.Scaling.Faith,
                        Arcane = shield.ShieldStats.Scaling.Arcane
                    },
                    Requires = new Requires
                    {
                        Endurance = shield.ShieldStats.Requires.Endurance,
                        Strength = shield.ShieldStats.Requires.Strength,
                        Dexterity = shield.ShieldStats.Requires.Dexterity,
                        Intelligence = shield.ShieldStats.Requires.Intelligence,
                        Faith = shield.ShieldStats.Requires.Faith,
                        Arcane = shield.ShieldStats.Requires.Arcane
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
