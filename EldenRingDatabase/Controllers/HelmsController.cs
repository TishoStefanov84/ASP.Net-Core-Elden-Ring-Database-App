namespace EldenRingDatabase.Controllers
{
    using EldenRingDatabase.Data;
    using EldenRingDatabase.Data.Models;
    using EldenRingDatabase.Models.Armors;
    using Microsoft.AspNetCore.Mvc;
    using System.Globalization;

    public class HelmsController : Controller
    {
        private readonly EldenRingDbContext data;

        public HelmsController(EldenRingDbContext data)
            => this.data = data;

        public IActionResult Add() => View(new AddHelmsFormModel());

        [HttpPost]
        public IActionResult Add(AddHelmsFormModel helm)
        {
            if (!this.ModelState.IsValid)
            {
                return View(helm);
            }

            var helmData = new Helm
            {
                Name = helm.Name,
                ImageUrl = helm.ImageUrl,
                Description = helm.Description,
                Weight = double.Parse(helm.Weight, CultureInfo.InvariantCulture),
                ArmorStats = new ArmorStats
                {
                    DmgNegation = new DmgNegation
                    {
                        Phy = double.Parse(helm.ArmorStats.DmgNegation.Phy, CultureInfo.InvariantCulture),
                        VSStrike = double.Parse(helm.ArmorStats.DmgNegation.VSStrike, CultureInfo.InvariantCulture),
                        VSSlash = double.Parse(helm.ArmorStats.DmgNegation.VSSlash, CultureInfo.InvariantCulture),
                        VSPierce = double.Parse(helm.ArmorStats.DmgNegation.VSPierce, CultureInfo.InvariantCulture),
                        Magic = double.Parse(helm.ArmorStats.DmgNegation.Magic, CultureInfo.InvariantCulture),
                        Fire = double.Parse(helm.ArmorStats.DmgNegation.Fire, CultureInfo.InvariantCulture),
                        Ligt = double.Parse(helm.ArmorStats.DmgNegation.Ligt, CultureInfo.InvariantCulture),
                        Holy = double.Parse(helm.ArmorStats.DmgNegation.Holy, CultureInfo.InvariantCulture)
                    },
                    Resistance = new Resistance
                    {
                        Immunity = helm.ArmorStats.Resistance.Immunity,
                        Robustness = helm.ArmorStats.Resistance.Robustness,
                        Focus = helm.ArmorStats.Resistance.Focus,
                        Vitality = helm.ArmorStats.Resistance.Vitality,
                        Poise = helm.ArmorStats.Resistance.Poise
                    }
                }
            };
            return RedirectToAction("Index", "Home");
        }
    }
}
