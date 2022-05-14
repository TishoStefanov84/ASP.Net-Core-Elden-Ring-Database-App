namespace EldenRingDatabase.Controllers
{
    using EldenRingDatabase.Data;
    using EldenRingDatabase.Data.Models;
    using EldenRingDatabase.Models.CharacterClasses;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    public class CharacterClassesController : Controller
    {
        private readonly EldenRingDbContext data;

        public CharacterClassesController(EldenRingDbContext data)
            => this.data = data;

        public IActionResult Add() => View(new AddCharacterClassFormModel
        {
            ArmorSets = this.GetArmorSet()
        });

        [HttpPost]
        public IActionResult Add(AddCharacterClassFormModel characterClass)
        {
            if (!this.data.ArmorSets.Any(a => a.Id == characterClass.ArmorSetId))
            {
                this.ModelState.AddModelError(nameof(characterClass.ArmorSetId), "Armor set not exist.");
            }
            if (!this.ModelState.IsValid)
            {
                characterClass.ArmorSets = GetArmorSet();

                return View(characterClass);
            }

            var characterClassData = new CharacterClass
            {
                Name = characterClass.Name,
                ImageUrl = characterClass.ImageUrl,
                Description = characterClass.Description,
                RuneLevel = characterClass.RuneLevel,
                Vigor = characterClass.Vigor,
                Mind = characterClass.Mind,
                Endurance = characterClass.Endurance,
                Strength = characterClass.Strength,
                Dexterity = characterClass.Dexterity,
                Intelligence = characterClass.Intelligence,
                Faith = characterClass.Faith,
                Arcane = characterClass.Arcane,
                ArmorSetId = characterClass.ArmorSetId
            };

            this.data.Add(characterClassData);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        private ICollection<ArmorSetViewModel> GetArmorSet()
            => this.data
            .ArmorSets
            .Select(a => new ArmorSetViewModel
            {
                Id = a.Id,
                Name = a.Name
            })
            .ToList();
    }
}
