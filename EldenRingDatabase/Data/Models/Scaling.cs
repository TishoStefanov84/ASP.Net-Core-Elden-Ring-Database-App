namespace EldenRingDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Scaling
    {
        public Scaling()
            => this.Stats = new HashSet<Stats>();

        public int Id { get; init; }

        [MaxLength(ScalingMaxLen)]
        public string Endurance { get; set; }

        [MaxLength(ScalingMaxLen)]
        public string Strength { get; set; }

        [MaxLength(ScalingMaxLen)]
        public string Dexterity { get; set; }

        [MaxLength(ScalingMaxLen)]
        public string Intelligence { get; set; }

        [MaxLength(ScalingMaxLen)]
        public string Faith { get; set; }

        [MaxLength(ScalingMaxLen)]
        public string Arcane { get; set; }

        public ICollection<Stats> Stats { get; init; }
    }
}