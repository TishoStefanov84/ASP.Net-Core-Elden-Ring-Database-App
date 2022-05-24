namespace EldenRingDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Talisman
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(TalismanNameMaxLen)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Descripption { get; set; }

        [Required]
        public string TalismanEffects { get; init; }

        public double Weight { get; set; }

        public bool IsLegendary { get; set; }
    }
}
