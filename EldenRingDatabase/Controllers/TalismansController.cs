namespace EldenRingDatabase.Controllers
{
    using EldenRingDatabase.Data;
    using EldenRingDatabase.Data.Models;
    using EldenRingDatabase.Models.Talismans;
    using Microsoft.AspNetCore.Mvc;
    using System.Globalization;

    public class TalismansController : Controller
    {
        private readonly EldenRingDbContext data;

        public TalismansController(EldenRingDbContext data)
            => this.data = data;

        public IActionResult Add() => this.View(new AddTalismanFormModel());

        [HttpPost]
        public IActionResult Add(AddTalismanFormModel talisman)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(talisman);
            }

            var talismanData = new Talisman
            {
                Name = talisman.Name,
                Descripption = talisman.Description,
                ImageUrl = talisman.ImageUrl,
                TalismanEffects = talisman.TalismanEffect,
                Weight = double.Parse(talisman.Weight, CultureInfo.InvariantCulture),
                IsLegendary = talisman.IsLegendary
            };


            this.data.Add(talismanData);
            this.data.SaveChanges();

            return this.RedirectToAction("Index", "Home");
        }
    }
}
