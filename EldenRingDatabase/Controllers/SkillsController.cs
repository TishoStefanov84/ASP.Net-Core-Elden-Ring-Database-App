namespace EldenRingDatabase.Controllers
{
    using EldenRingDatabase.Data;
    using EldenRingDatabase.Data.Models;
    using EldenRingDatabase.Models.Skills;
    using Microsoft.AspNetCore.Mvc;

    public class SkillsController : Controller
    {
        private readonly EldenRingDbContext data;

        public SkillsController(EldenRingDbContext data)
            => this.data = data;

        public IActionResult Add() => View(new AddSkillFormModel());

        [HttpPost]
        public IActionResult Add(AddSkillFormModel skill)
        {
            if (!this.ModelState.IsValid)
            {
                return View(skill);
            }

            var skillData = new Skill
            {
                Name = skill.Name,
                ImageUrl = skill.ImageUrl,
                Description = skill.Description,
                FPCost = skill.FPCost
            };

            this.data.Add(skillData);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
