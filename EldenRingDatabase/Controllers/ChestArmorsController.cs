namespace EldenRingDatabase.Controllers
{
    using EldenRingDatabase.Data;
    using EldenRingDatabase.Data.Models;
    using EldenRingDatabase.Models.Armors;
    using Microsoft.AspNetCore.Mvc;
    using System.Globalization;

    public class ChestArmorsController : Controller
    {
        private readonly EldenRingDbContext data;

        public ChestArmorsController(EldenRingDbContext data)
            => this.data = data;

        public IActionResult Add() => View(new AddChestArmorsFormModel());

        [HttpPost]
        public IActionResult Add(AddChestArmorsFormModel chestArmor)
        {
            if (!this.ModelState.IsValid)
            {
                return View(chestArmor);
            }

            var chestArmorData = new ChestArmor
            {
                Name = chestArmor.Name,
                ImageUrl = chestArmor.ImageUrl,
                Description = chestArmor.Description,
                Weight = double.Parse(chestArmor.Weight, CultureInfo.InvariantCulture),
                ArmorStats = new ArmorStats
                {
                    DmgNegation = new DmgNegation
                    {
                        Phy = double.Parse(chestArmor.ArmorStats.DmgNegation.Phy, CultureInfo.InvariantCulture),
                        VSStrike = double.Parse(chestArmor.ArmorStats.DmgNegation.VSStrike, CultureInfo.InvariantCulture),
                        VSSlash = double.Parse(chestArmor.ArmorStats.DmgNegation.VSSlash, CultureInfo.InvariantCulture),
                        VSPierce = double.Parse(chestArmor.ArmorStats.DmgNegation.VSPierce, CultureInfo.InvariantCulture),
                        Magic = double.Parse(chestArmor.ArmorStats.DmgNegation.Magic, CultureInfo.InvariantCulture),
                        Fire = double.Parse(chestArmor.ArmorStats.DmgNegation.Fire, CultureInfo.InvariantCulture),
                        Ligt = double.Parse(chestArmor.ArmorStats.DmgNegation.Ligt, CultureInfo.InvariantCulture),
                        Holy = double.Parse(chestArmor.ArmorStats.DmgNegation.Holy, CultureInfo.InvariantCulture)
                    },
                    Resistance = new Resistance
                    {
                        Immunity = chestArmor.ArmorStats.Resistance.Immunity,
                        Robustness = chestArmor.ArmorStats.Resistance.Robustness,
                        Focus = chestArmor.ArmorStats.Resistance.Focus,
                        Vitality = chestArmor.ArmorStats.Resistance.Vitality,
                        Poise = chestArmor.ArmorStats.Resistance.Poise
                    }
                }
            };


            this.data.Add(chestArmorData);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
