namespace EldenRingDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class AmmunitionType
    {
        public AmmunitionType()
            => this.Ammunitions = new HashSet<Ammunition>();

        public int Id { get; init; }

        [Required]
        [MaxLength(AmmunitionTypeNameMaxLen)]
        public string Name { get; set; }

        public ICollection<Ammunition> Ammunitions { get; init; }
    }
}