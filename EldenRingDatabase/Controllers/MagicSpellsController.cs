namespace EldenRingDatabase.Controllers
{
    using EldenRingDatabase.Data;
    using EldenRingDatabase.Data.Models;
    using EldenRingDatabase.Models.MagicSpells;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MagicSpellsController : Controller
    {
        private readonly EldenRingDbContext data;

        public MagicSpellsController(EldenRingDbContext data)
            => this.data = data;

        public IActionResult Add() => this.View(new AddMagicSpellFormModel
        {
            MagicSpellType = this.GetMagicSpellType()
        });

        [HttpPost]
        public IActionResult Add(AddMagicSpellFormModel magicSpell)
        {
            if (!this.data.MagicSpellType.Any(m => m.Id == magicSpell.MagicSpellTypeId))
            {
                this.ModelState.AddModelError(nameof(magicSpell.MagicSpellTypeId), "Magic spell type not exist.");
            }

            if (!this.ModelState.IsValid)
            {
                magicSpell.MagicSpellType = this.GetMagicSpellType();

                return this.View(magicSpell);
            }

            var magicSpellData = new MagicSpell
            {
                Name = magicSpell.Name,
                MagicSpellTypeId = magicSpell.MagicSpellTypeId,
                ImageUrl = magicSpell.ImageUrl,
                Description = magicSpell.Description,
                IsLegendary = magicSpell.IsLegendary,
                Effect = magicSpell.Effect,
                SlotUsed = magicSpell.SlotUsed,
                FPCost = magicSpell.FPCost,
                Requires = new Requires
                {
                    Endurance = magicSpell.Requires.Endurance,
                    Strength = magicSpell.Requires.Strength,
                    Dexterity = magicSpell.Requires.Dexterity,
                    Intelligence = magicSpell.Requires.Intelligence,
                    Faith = magicSpell.Requires.Faith,
                    Arcane = magicSpell.Requires.Arcane
                }
            };

            this.data.Add(magicSpellData);
            this.data.SaveChanges();

            return this.RedirectToAction("Index", "Home");
        }

        private ICollection<MagicSpellTypeViewModel> GetMagicSpellType()
            => this.data
            .MagicSpellType
            .Select(m => new MagicSpellTypeViewModel
            {
                Id = m.Id,
                Name = m.MagicSpellTypeName
            })
            .ToList();
    }
}
