namespace EldenRingDatabase.Controllers
{
    using EldenRingDatabase.Data;
    using EldenRingDatabase.Data.Models;
    using EldenRingDatabase.Models.StatusEffects;
    using Microsoft.AspNetCore.Mvc;

    public class StatusEffectsController : Controller
    {
        private readonly EldenRingDbContext data;

        public StatusEffectsController(EldenRingDbContext data)
            => this.data = data;

        public IActionResult Add() => View(new AddStatusEffectFormModel());

        [HttpPost]
        public IActionResult Add(AddStatusEffectFormModel statusEffect)
        {
            if (!this.ModelState.IsValid)
            {
                return View(statusEffect);
            }

            var statusEffectData = new StatusEffect
            {
                Name = statusEffect.Name,
                ImageUrl = statusEffect.ImageUrl,
                Effect = statusEffect.Effect,
                Description = statusEffect.Description
            };

            this.data.Add(statusEffectData);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
