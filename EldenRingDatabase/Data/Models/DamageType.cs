namespace EldenRingDatabase.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class DamageType
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(DamageTypeNameMaxLen)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}