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

        public IActionResult Add()
        {
            var characterModel = new AddCharacterClassFormModel
            {
                ArmorSets = this.GetArmorSet(),
                Weapons = this.GetWeapon(),
                Shields = this.GetShield(),
                MagicSpells = this.GetMagicSpell(),
                Ammunitions = this.GetAmmunition()
            };

            return this.View(characterModel);
        }

        [HttpPost]
        public IActionResult Add(AddCharacterClassFormModel characterClass)
        {
            if (!this.data.ArmorSets.Any(a => a.Id == characterClass.ArmorSetId))
            {
                this.ModelState.AddModelError(nameof(characterClass.ArmorSetId), "Armor set not exist.");
            }

            if (!this.ModelState.IsValid)
            {
                characterClass.ArmorSets = this.GetArmorSet();
                characterClass.Weapons = this.GetWeapon();
                characterClass.Shields = this.GetShield();
                characterClass.MagicSpells = this.GetMagicSpell();
                characterClass.Ammunitions = this.GetAmmunition();

                return this.View(characterClass);
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
                ArmorSetId = characterClass.ArmorSetId,
                Equipment = new Equipment
                {
                    Weapons = this.AddWeapons(characterClass),
                    Shields = this.AddShields(characterClass),
                    MagicSpells = this.AddMagicSpells(characterClass),
                    Ammunitions = this.AddAmmunitions(characterClass)
                }
            };

            ;

            this.data.Add(characterClassData);
            this.data.SaveChanges();

            return this.RedirectToAction("Index", "Home");
        }

        private List<Weapon> AddWeapons(AddCharacterClassFormModel model)
        {
            var weapons = new List<Weapon>();

            if (model.WeaponId != null)
            {
                foreach (var id in model.WeaponId)
                {
                    var weapon = this.data.Weapons.Where(w => w.Id == id).First();
                    weapons.Add(weapon);
                }
            }
            

            return weapons;
        }

        private List<Shield> AddShields(AddCharacterClassFormModel model)
        {
            var shields = new List<Shield>();

            if (model.ShieldId != null)
            {
                foreach (var id in model.ShieldId)
                {
                    var shield = this.data.Shields.Where(w => w.Id == id).First();
                    shields.Add(shield);
                }
            }
           

            return shields;
        }

        private List<MagicSpell> AddMagicSpells(AddCharacterClassFormModel model)
        {
            var magicSpells = new List<MagicSpell>();

            if (model.MagicSpellId != null)
            {
                foreach (var id in model.MagicSpellId)
                {
                    var magicSpell = this.data.MagicSpells.Where(w => w.Id == id).First();
                    magicSpells.Add(magicSpell);
                }
            }

            return magicSpells;
        }

        private List<Ammunition> AddAmmunitions(AddCharacterClassFormModel model)
        {
            var ammunitions = new List<Ammunition>();

            if (model.AmmunitionId != null)
            {
                foreach (var id in model.AmmunitionId)
                {
                    var ammunition = this.data.Ammunitions.Where(w => w.Id == id).First();
                    ammunitions.Add(ammunition);
                }
            }
            

            return ammunitions;
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

        private ICollection<WeaponViewModel> GetWeapon()
            => this.data
            .Weapons
            .Select(w => new WeaponViewModel
            {
                Id = w.Id,
                Name = w.Name
            })
            .ToList();

        private ICollection<AmmunitionViewModel> GetAmmunition()
            => this.data
            .Ammunitions
            .Select(a => new AmmunitionViewModel
            {
                Id = a.Id,
                Name = a.Name
            })
            .ToList();

        private ICollection<MagicSpellViewModel> GetMagicSpell()
            => this.data
            .MagicSpells
            .Select(m => new MagicSpellViewModel
            {
                Id = m.Id,
                Name = m.Name
            })
            .ToList();

        private ICollection<ShieldViewModel> GetShield()
            => this.data
            .Shields
            .Select(s => new ShieldViewModel
            {
                Id = s.Id,
                Name = s.Name
            })
            .ToList();
    }
}
