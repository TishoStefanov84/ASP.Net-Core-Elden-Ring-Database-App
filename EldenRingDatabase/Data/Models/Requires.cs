namespace EldenRingDatabase.Data.Models
{
    using System.Collections.Generic;

    public class Requires
    {
        public Requires()
            => this.Stats = new HashSet<Stats>();

        public int Id { get; init; }

        public int Endurance { get; set; }

        public int Strength { get; set; }

        public int Dexterity { get; set; }

        public int Intelligence { get; set; }

        public int Faith { get; set; }

        public int Arcane { get; set; }

        public ICollection<Stats> Stats { get; init; }
    }
}