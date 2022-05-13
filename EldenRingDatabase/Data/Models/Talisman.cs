namespace EldenRingDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Talisman
    {
        public Talisman()
            => this.TalismanEffects = new HashSet<TalismanEffect>();

        public int Id { get; init; }

        [Required]
        [MaxLength(TalismanNameMaxLen)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Descripption { get; set; }

        [Required]
        public double Weight { get; set; }

        public ICollection<TalismanEffect> TalismanEffects { get; init; }
    }
}
