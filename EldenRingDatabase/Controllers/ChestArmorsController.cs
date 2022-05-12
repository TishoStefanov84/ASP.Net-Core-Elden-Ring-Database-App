namespace EldenRingDatabase.Controllers
{
    using EldenRingDatabase.Data;
    using EldenRingDatabase.Data.Models;
    using EldenRingDatabase.Models.Armors;
    using Microsoft.AspNetCore.Mvc;

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
                Weight = chestArmor.Weight,
                ArmorStats = new ArmorStats
                {
                    DmgNegation = new DmgNegation
                    {
                        Phy = chestArmor.ArmorStats.DmgNegation.Phy,
                        VSStrike = chestArmor.ArmorStats.DmgNegation.VSStrike,
                        VSSlash = chestArmor.ArmorStats.DmgNegation.VSSlash,
                        VSPierce = chestArmor.ArmorStats.DmgNegation.VSPierce,
                        Magic = chestArmor.ArmorStats.DmgNegation.Magic,
                        Fire = chestArmor.ArmorStats.DmgNegation.Fire,
                        Ligt = chestArmor.ArmorStats.DmgNegation.Ligt,
                        Holy = chestArmor.ArmorStats.DmgNegation.Holy
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
