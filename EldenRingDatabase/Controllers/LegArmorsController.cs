namespace EldenRingDatabase.Controllers
{
    using EldenRingDatabase.Data;
    using EldenRingDatabase.Data.Models;
    using EldenRingDatabase.Models.Armors;
    using Microsoft.AspNetCore.Mvc;
    using System.Globalization;

    public class LegArmorsController : Controller
    {
        private readonly EldenRingDbContext data;

        public LegArmorsController(EldenRingDbContext data)
            => this.data = data;

        public IActionResult Add() => View(new AddLegArmorsFormModel());

        [HttpPost]
        public IActionResult Add(AddLegArmorsFormModel legArmor)
        {
            if (!this.ModelState.IsValid)
            {
                return View(legArmor);
            }

            var legArmorData = new LegArmor 
            {
                Name = legArmor.Name,
                ImageUrl = legArmor.ImageUrl,
                Description = legArmor.Description,
                Weight = double.Parse(legArmor.Weight, CultureInfo.InvariantCulture),
                ArmorStats = new ArmorStats
                {
                    DmgNegation = new DmgNegation
                    {
                        Phy = double.Parse(legArmor.ArmorStats.DmgNegation.Phy, CultureInfo.InvariantCulture),
                        VSStrike = double.Parse(legArmor.ArmorStats.DmgNegation.VSStrike, CultureInfo.InvariantCulture),
                        VSSlash = double.Parse(legArmor.ArmorStats.DmgNegation.VSSlash, CultureInfo.InvariantCulture),
                        VSPierce = double.Parse(legArmor.ArmorStats.DmgNegation.VSPierce, CultureInfo.InvariantCulture),
                        Magic = double.Parse(legArmor.ArmorStats.DmgNegation.Magic, CultureInfo.InvariantCulture),
                        Fire = double.Parse(legArmor.ArmorStats.DmgNegation.Fire, CultureInfo.InvariantCulture),
                        Ligt = double.Parse(legArmor.ArmorStats.DmgNegation.Ligt, CultureInfo.InvariantCulture),
                        Holy = double.Parse(legArmor.ArmorStats.DmgNegation.Holy, CultureInfo.InvariantCulture)
                    },
                    Resistance = new Resistance
                    {
                        Immunity = legArmor.ArmorStats.Resistance.Immunity,
                        Robustness = legArmor.ArmorStats.Resistance.Robustness,
                        Focus = legArmor.ArmorStats.Resistance.Focus,
                        Vitality = legArmor.ArmorStats.Resistance.Vitality,
                        Poise = legArmor.ArmorStats.Resistance.Poise
                    }
                }
            };

            return RedirectToAction("Index", "Home");
        }
    }
}
