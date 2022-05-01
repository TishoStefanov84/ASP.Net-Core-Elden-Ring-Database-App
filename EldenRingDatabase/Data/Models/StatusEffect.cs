namespace EldenRingDatabase.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;
    public class StatusEffect
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(StatusEffectNameMaxLen)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Effect { get; set; }

        [Required]
        public string Description { get; set; }
    }
}