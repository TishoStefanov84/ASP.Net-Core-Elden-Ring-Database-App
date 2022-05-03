namespace EldenRingDatabase.Controllers
{
    using EldenRingDatabase.Data;
    using EldenRingDatabase.Data.Models;
    using EldenRingDatabase.Models;
    using EldenRingDatabase.Models.Ammunitions;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    public class AmmunitionsController : Controller
    {
        private readonly EldenRingDbContext data;

        public AmmunitionsController(EldenRingDbContext data)
            => this.data = data;

        public IActionResult Add() => View(new AddAmmunitionFormModel
        {
            AmmunitionTypes = this.GetAmmunitionTypes(),
            DamageTypes = this.GetDamageTypes()
        });

        [HttpPost]
        public IActionResult Add(AddAmmunitionFormModel ammunition, AttackStatsViewModel attackStats)
        {
            if (!this.data.AmmunitionTypes.Any(a => a.Id == ammunition.AmmunitionTypeId))
            {
                this.ModelState.AddModelError(nameof(ammunition.AmmunitionTypeId), "Ammunition type not exist.");
            }

            if (!this.data.DamageTypes.Any(d => d.Id == ammunition.DamageTypeId))
            {
                this.ModelState.AddModelError(nameof(ammunition.DamageTypeId), "Damage type not exist.");
            }

            if (!this.ModelState.IsValid)
            {
                ammunition.AmmunitionTypes = GetAmmunitionTypes();
                ammunition.DamageTypes = GetDamageTypes();

                return View(ammunition);
            }

            var ammunitionData = new Ammunition
            {
                Name = ammunition.Name,
                Description = ammunition.Description,
                ImageUrl = ammunition.ImageUrl,
                AmmunitionTypeId = ammunition.AmmunitionTypeId,
                DamageTypeId = ammunition.DamageTypeId,
                AttackStats = new AttackStats
                {
                    Phy = attackStats.Phy,
                    Mag = attackStats.Mag,
                    Fire = attackStats.Fire,
                    Ligt = attackStats.Ligt,
                    Holy = attackStats.Holy,
                    Crit = attackStats.Crit,
                    Sor = attackStats.Sor,
                    Inc = attackStats.Inc
                }
             };


            this.data.Add(ammunitionData);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        private ICollection<AmmunitionTypeViewModel> GetAmmunitionTypes()
            => this.data
            .AmmunitionTypes
            .Select(a => new AmmunitionTypeViewModel
            {
                Id = a.Id,
                Name = a.Name
            })
            .ToList();

        private ICollection<DamageTypeViewModel> GetDamageTypes()
            => this.data
            .DamageTypes
            .Select(a => new DamageTypeViewModel
            {
                Id = a.Id,
                Name = a.Name
            })
            .ToList();
    }
}
