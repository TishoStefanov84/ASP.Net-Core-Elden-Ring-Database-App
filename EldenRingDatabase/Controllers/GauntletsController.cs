namespace EldenRingDatabase.Controllers
{
    using EldenRingDatabase.Data;
    using EldenRingDatabase.Data.Models;
    using EldenRingDatabase.Models.Armors;
    using Microsoft.AspNetCore.Mvc;
    using System.Globalization;

    public class GauntletsController : Controller
    {
        private readonly EldenRingDbContext data;

        public GauntletsController(EldenRingDbContext data)
            => this.data = data;

        public IActionResult Add() => View(new AddGauntletsFormModel());

        [HttpPost]
        public IActionResult Add(AddGauntletsFormModel gauntlets)
        {
            if (!this.ModelState.IsValid)
            {
                return View(gauntlets);
            }

            var gauntletsData = new Gauntlets
            {
                Name = gauntlets.Name,
                ImageUrl = gauntlets.ImageUrl,
                Description = gauntlets.Description,
                Weight = double.Parse(gauntlets.Weight, CultureInfo.InvariantCulture),
                ArmorStats = new ArmorStats
                {
                    DmgNegation = new DmgNegation
                    {
                        Phy = double.Parse(gauntlets.ArmorStats.DmgNegation.Phy, CultureInfo.InvariantCulture),
                        VSStrike = double.Parse(gauntlets.ArmorStats.DmgNegation.VSStrike, CultureInfo.InvariantCulture),
                        VSSlash = double.Parse(gauntlets.ArmorStats.DmgNegation.VSSlash, CultureInfo.InvariantCulture),
                        VSPierce = double.Parse(gauntlets.ArmorStats.DmgNegation.VSPierce, CultureInfo.InvariantCulture),
                        Magic = double.Parse(gauntlets.ArmorStats.DmgNegation.Magic, CultureInfo.InvariantCulture),
                        Fire = double.Parse(gauntlets.ArmorStats.DmgNegation.Fire, CultureInfo.InvariantCulture),
                        Ligt = double.Parse(gauntlets.ArmorStats.DmgNegation.Ligt, CultureInfo.InvariantCulture),
                        Holy = double.Parse(gauntlets.ArmorStats.DmgNegation.Holy, CultureInfo.InvariantCulture)
                    },
                    Resistance = new Resistance
                    {
                        Immunity = gauntlets.ArmorStats.Resistance.Immunity,
                        Robustness = gauntlets.ArmorStats.Resistance.Robustness,
                        Focus = gauntlets.ArmorStats.Resistance.Focus,
                        Vitality = gauntlets.ArmorStats.Resistance.Vitality,
                        Poise = gauntlets.ArmorStats.Resistance.Poise
                    }
                }
            };

            this.data.Add(gauntletsData);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
