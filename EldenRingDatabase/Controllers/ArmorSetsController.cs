namespace EldenRingDatabase.Controllers
{
    using EldenRingDatabase.Data;
    using EldenRingDatabase.Data.Models;
    using EldenRingDatabase.Models.Armors;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;

    public class ArmorSetsController : Controller
    {
        private readonly EldenRingDbContext data;

        public ArmorSetsController(EldenRingDbContext data)
            => this.data = data;

        public IActionResult Add() => View(new AddArmorSetFormModel());

        [HttpPost]
        public IActionResult Add(AddArmorSetFormModel armorSet)
        {
            if (!this.ModelState.IsValid)
            {
                return View(armorSet);
            }

            var helmId = GetHelmId(armorSet.Name);
            var chestArmorId = GetChestArmorId(armorSet.Name);
            var gauntletsId = GetGauntletsId(armorSet.Name);
            var legArmorId = GetLegArmorId(armorSet.Name);

            var armorSetStats = GetStats(helmId, chestArmorId, gauntletsId, legArmorId);

            var weight = GetWeight(helmId, chestArmorId, gauntletsId, legArmorId);

            var armorSetData = new ArmorSet
            {
                Name = armorSet.Name,
                ImageUrl = armorSet.ImageUrl,
                Description = armorSet.Description,
                HelmId = helmId,
                ChestArmorId = chestArmorId,
                GauntletsId = gauntletsId,
                LegArmorId = legArmorId,
                ArmorStats = armorSetStats,
                Weight = weight
            };

            this.data.Add(armorSetData);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        private double GetWeight(int helmId, int chestArmorId, int gauntletsId, int legArmorId)
        {
            var helm = this.data.Helms
                .Where(h => h.Id == helmId)
                .FirstOrDefault();

            var chestArmor = this.data.ChestArmors
                .Where(c => c.Id == chestArmorId)
                .FirstOrDefault();

            var gauntlets = this.data.Gauntlets
                .Where(g => g.Id == gauntletsId)
                .FirstOrDefault();

            var legArmor = this.data.LegArmor
                .Where(l => l.Id == legArmorId)
                .FirstOrDefault();

            var weight = Math.Round(helm.Weight + chestArmor.Weight + gauntlets.Weight + legArmor.Weight, 1);

            return weight;
        }

        private ArmorStats GetStats(int helmId, int chestArmorId, int gauntletsId, int legArmorId)
        {
            var helm = this.data.Helms
                .Where(h => h.Id == helmId)
                .FirstOrDefault();

            var helmStats = this.data.ArmorStats
               .Where(a => a.Id == helm.ArmorStatsId)
               .FirstOrDefault();

            var helmDmgNegation = GetDmgNegation(helmStats);
            var helmResistance = GetResistance(helmStats);

            var chestArmor = this.data.ChestArmors
                .Where(c => c.Id == chestArmorId)
                .FirstOrDefault();

            var chestArmorStats = this.data.ArmorStats
                .Where(a => a.Id == chestArmor.ArmorStatsId)
                .FirstOrDefault();

            var chestArmorDmgNegation = GetDmgNegation(chestArmorStats);
            var chestArmorResistance = GetResistance(chestArmorStats);

            var gauntlets = this.data.Gauntlets
                .Where(g => g.Id == gauntletsId)
                .FirstOrDefault();

            var gauntletsStats = this.data.ArmorStats
                .Where(a => a.Id == gauntlets.ArmorStatsId)
                .FirstOrDefault();

            var gauntletsDmgNegation = GetDmgNegation(gauntletsStats);
            var gauntletsResistance = GetResistance(gauntletsStats);

            var legArmor = this.data.LegArmor
                .Where(l => l.Id == legArmorId)
                .FirstOrDefault();

            var legArmorStats = this.data.ArmorStats
                .Where(a => a.Id == legArmor.ArmorStatsId)
                .FirstOrDefault();

            var legArmorDmgNegation = GetDmgNegation(legArmorStats);
            var legArmorResistance = GetResistance(legArmorStats);

            var dmgNegation = CalcDmgNegation(helmDmgNegation, chestArmorDmgNegation, gauntletsDmgNegation, legArmorDmgNegation);
            var resistance = CalcResistance(helmResistance, chestArmorResistance, gauntletsResistance, legArmorResistance);

            var armorStats = new ArmorStats
            {
                DmgNegation = dmgNegation,
                Resistance = resistance
            };

            return armorStats;
        }

        private DmgNegation GetDmgNegation(ArmorStats obj)
            => this.data.DmgNegations
            .Where(d => d.Id == obj.DmgNegationId)
            .FirstOrDefault();

        private Resistance GetResistance(ArmorStats obj)
            => this.data.Resistances
            .Where(d => d.Id == obj.ResistanceId)
            .FirstOrDefault();

        private Resistance CalcResistance(Resistance helm, Resistance chestArmor, Resistance gauntlets, Resistance legArmor)
        {
            var immunity = helm.Immunity +
                            chestArmor.Immunity +
                            gauntlets.Immunity +
                            legArmor.Immunity;

            var robustness = helm.Robustness +
                            chestArmor.Robustness +
                            gauntlets.Robustness +
                            legArmor.Robustness;

            var focus = helm.Focus +
                            chestArmor.Focus +
                            gauntlets.Focus +
                            legArmor.Focus;

            var vitality = helm.Vitality +
                            chestArmor.Vitality +
                            gauntlets.Vitality +
                            legArmor.Vitality;

            var poise = helm.Poise +
                            chestArmor.Poise +
                            gauntlets.Poise +
                            legArmor.Poise;

            var resistance = new Resistance
            {
                Immunity = immunity,
                Robustness = robustness,
                Focus = focus,
                Vitality = vitality,
                Poise = poise
            };

            return resistance;
        }

        private DmgNegation CalcDmgNegation(DmgNegation helm, DmgNegation chestArmor, DmgNegation gauntlets, DmgNegation legArmor)
        {

            var phy = Math.Round(helm.Phy +
                chestArmor.Phy +
                gauntlets.Phy +
                legArmor.Phy, 1);

            var vsStrike = Math.Round(helm.VSStrike +
                chestArmor.VSStrike +
                gauntlets.VSStrike +
                legArmor.VSStrike, 1);

            var vsSlash = Math.Round(helm.VSSlash +
                chestArmor.VSSlash +
                gauntlets.VSSlash +
                legArmor.VSSlash, 1);

            var vsPierce = Math.Round(helm.VSPierce +
                chestArmor.VSPierce +
                gauntlets.VSPierce +
                legArmor.VSPierce, 1);

            var magic = Math.Round(helm.Magic +
                chestArmor.Magic +
                gauntlets.Magic +
                legArmor.Magic, 1);

            var fire = Math.Round(helm.Fire +
                chestArmor.Fire +
                gauntlets.Fire +
                legArmor.Fire, 1);

            var ligt = Math.Round(helm.Ligt +
                chestArmor.Ligt +
                gauntlets.Ligt +
                legArmor.Ligt, 1);

            var holy = Math.Round(helm.Holy +
                chestArmor.Holy +
                gauntlets.Holy +
                legArmor.Holy, 1);

            var dmgNegation = new DmgNegation
            {
                Phy = phy,
                VSStrike = vsStrike,
                VSSlash = vsSlash,
                VSPierce = vsPierce,
                Magic = magic,
                Fire = fire,
                Ligt = ligt,
                Holy = holy
            };

            return dmgNegation;
        }

        private int GetLegArmorId(string setName)
        {
            var name = setName.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var legArmorName = string.Join(" ", name.Take(name.Length - 1));

            var legArmor = this.data.LegArmor
                .Where(l => l.Name.StartsWith(legArmorName))
                .FirstOrDefault();

            if (legArmor == null)
            {
                this.ModelState.AddModelError(nameof(legArmorName), "Leg armor not exist.");
            }

            return legArmor.Id;
        }

        private int GetGauntletsId(string setName)
        {
            var name = setName.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var gauntletsName = string.Join(" ", name.Take(name.Length - 1));

            var gauntlets = this.data.Gauntlets
                .Where(g => g.Name.StartsWith(gauntletsName))
                .FirstOrDefault();

            if (gauntlets == null)
            {
                this.ModelState.AddModelError(nameof(gauntletsName), "Gauntlets not exist.");
            }

            return gauntlets.Id;
        }

        private int GetChestArmorId(string setName)
        {
            var name = setName.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var chestArmorName = string.Join(" ", name.Take(name.Length - 1));

            var chestArmor = this.data.ChestArmors
                .Where(c => c.Name.StartsWith(chestArmorName))
                .FirstOrDefault();

            if (chestArmor == null)
            {
                this.ModelState.AddModelError(nameof(chestArmorName), "Chest armor not exist.");
            }

            return chestArmor.Id;
        }

        private int GetHelmId(string setName)
        {
            var name = setName.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var helmName = string.Join(" ", name.Take(name.Length - 1));

            var helm = this.data.Helms
                .Where(h => h.Name.StartsWith(helmName))
                .FirstOrDefault();


            if (helm == null)
            {
                this.ModelState.AddModelError(nameof(helmName), "Helm not exist.");
            }

            return helm.Id;
        }
    }
}
