namespace EldenRingDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class ShieldType
    {
        public ShieldType()
          => this.Shields = new HashSet<Shield>();

        public int Id { get; init; }

        [Required]
        [MaxLength(ShieldTypeNameMaxLen)]
        public string Name { get; set; }

        public ICollection<Shield> Shields { get; init; }
    }
}