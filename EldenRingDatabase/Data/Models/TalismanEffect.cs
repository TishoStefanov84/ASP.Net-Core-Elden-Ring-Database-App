namespace EldenRingDatabase.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class TalismanEffect
    {
        public int Id { get; init; }

        [Required]
        public string Effect { get; set; }

        public int TalismanId { get; set; }

        public Talisman Talisman { get; set; }
    }
}